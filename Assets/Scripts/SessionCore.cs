using System;
using System.Collections;
using System.Collections.Generic;
using Controlers;
using Models;
using Presenters;
using ScriptableObjects.GameTier;
using ScriptableObjects.UserPersons;
using SwipeToCompleteThreeInRow;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SessionCore : MonoBehaviour
{
    [SerializeField] 
    public UserPersonsListScrObj UserPersonsListScrObj;
    
    public UserDataModel userData;

    public SwipeControler SwipeControler;
    public CombinationsControler CombinationsControler;
    public ConvertToExpControler ConvertToExpControler;
    public SessionScreensControler ScreensControler;
    public UserDataControler UserDataControler;
    public GameTierControler GameTierControler;
    public ColorSchemeControler ColorSchemeControler;
    public SessionInitializationControler SessionInitControler;
    // views
    public UserLevel UserLevel;
    public SwipeLevel SwipeLevel;
    // geted iten
    public GameTierScrObj GameTier;
    public Transform currentPos;
    private Platform Platform;
    // element
    private Element currentElement;
    [SerializeField]
    private Element elementPrefab;

    // Start is called before the first frame update
    private void Awake()
    {
        CreateMainControlers();
        GetUserData();
        EventsSubscription();
        SessionInitialization();
        
        CreateOverControlers();
    }

    void CreateMainControlers()
    {
        UserDataControler = new UserDataControler();
    }
    void GetUserData()
    {
        userData = UserDataControler.LoadData();
        UserLevel.SetData(userData);
    }

    void SaveUserData()
    {
        UserDataControler.SaveData(userData);
    }
   
    void CreateOverControlers()
    {
        SwipeControler = new SwipeControler(Platform);
        CombinationsControler = new CombinationsControler(Platform);
        ConvertToExpControler = new ConvertToExpControler(SwipeLevel,UserPersonsListScrObj.userLevels[userData.currentPerson]);
    }
    
    void EventsSubscription()
    {
        SwipeDetector.OnSwipe += OnSwipe;
        UserLevel.UserDefeat += Defeat;
        UserLevel.UserNewLevel += NewLevel;
    }

    public void RestartSession()
    {
        SceneManager.LoadScene(1);
    }

    public void SessionInitialization()
    {
        GameTier = GameTierControler.GetCurrentGameTier(userData);
        SessionInitControler.SessionInitialization(GameTier);
        Platform = SessionInitControler.GetPlatform();
        ColorSchemeControler.SetColors(GameTier.colorCheme);
        
        CreateCurrentElement();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    void OnSwipe(SwipeDetector.SwipeData swipeData)
    {
        if (SwipeControler.SwipeSolution(swipeData, currentElement))
        {
            Step();
        }
    }

    public void SessionDeinitialization()
    {
        Platform.DestroyPanel();
    }
    void Defeat()
    {
        ScreensControler.ShowDefeatPanel();
    }

    // запуск задачи для перехода на следующий уровень. Если задача решена - переход на уровень.
    // сообщение меняется с "collect point на Complete Pazl" плашка с коллект поинт уезжает и приезжает  лпашка с собрать пазл , после этого активируется таймер и пользователь за отведенное время должен собраь пазл
    void NewLevel()
    {
        UserDataControler.SaveData(userData);
        ScreensControler.ShowNewLevelPanel();
        
        SessionDeinitialization();
        GetUserData();
        SessionInitialization();
        CreateOverControlers();
    }
    
    void Step()
    {
        CheckCombinations();
        SwipeLevel.AddPointsToSwipeLevel();
        CreateCurrentElement();
    }

    void FillFreeCicle()
    {
        Platform.FillFreePoints();  
        CheckCombinations();
    }
    
    void CheckCombinations()
    {
        List<Point> combinatedPoints = CombinationsControler.SearchCombinations();
        if(combinatedPoints.Count != 0) UserLevel.AddExpirence(ConvertToExpControler.Convert(combinatedPoints));
        if(combinatedPoints.Count != 0) Platform.DeletePointsCombinations(combinatedPoints);
        if(combinatedPoints.Count != 0) FillFreeCicle(); 
    }
    
    void CreateCurrentElement()
    {
        currentElement = Instantiate(elementPrefab, currentPos);
        currentElement.CreateElement(UserPersonsListScrObj.userLevels[userData.currentPerson].PersonSprite);
    }
    
    private void OnDestroy()
    {
        SwipeDetector.OnSwipe -= OnSwipe;
        UserLevel.UserDefeat -= Defeat;
        UserLevel.UserNewLevel -= NewLevel;
        SaveUserData();
    }
}
