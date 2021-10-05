using System;
using System.Collections;
using System.Collections.Generic;
using Controlers;
using Models;
using Presenters;
using ScriptableObjects.UserPersons;
using SwipeToCompleteThreeInRow;
using SwipeToCompleteThreeInRow.Person;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SessionCore : MonoBehaviour
{
    [SerializeField] 
    public UserPersonsListScrObj UserPersonsListScrObj;

    public IPerson CurrentPersonType;
    public UserDataModel userData;
    public Platform Platform;
    
    public SwipeControler SwipeControler;
    public CombinationsControler CombinationsControler;
    public ConvertToExpControler ConvertToExpControler;
    public SessionScreensControler ScreensControler;
    public UserDataControler UserDataControler;
    
    public UserLevel UserLevel;
    public SwipeLevel SwipeLevel;
    public GameObject Canvas;
    public Element currentElement;
    public Element elementPrefab;

    public Transform currentPos;
    
    // Start is called before the first frame update
    private void Awake()
    {
        CreateMainControlers();
        LoadUserData();
        EventsSubscription();
        CreateOverControlers();
        
        CreateCurrentElement();
    }

    void CreateMainControlers()
    {
        UserDataControler = new UserDataControler();
    }
    void LoadUserData()
    {
        userData = UserDataControler.LoadData();
        UserLevel.SetData(userData);
        CurrentPersonType = UserPersonsListScrObj.userLevels[userData.currentPerson].PersonType.GetComponent<IPerson>();
        elementPrefab = UserPersonsListScrObj.userLevels[userData.currentPerson].PersonObject.GetComponent<Element>();
    }

    void SaveUserData()
    {
        UserDataControler.SaveData(userData);
    }
    void EventsSubscription()
    {
        SwipeDetector.OnSwipe += OnSwipe;
        UserLevel.UserDefeat += Defeat;
        UserLevel.UserNewLevel += NewLevel;
    }
    
    void CreateOverControlers()
    {
        Platform = new Platform(5,5, Canvas.transform);
        SwipeControler = new SwipeControler(Platform);
        CombinationsControler = new CombinationsControler(Platform);
        ConvertToExpControler = new ConvertToExpControler(CurrentPersonType);
    }

    public void RestartSession()
    {
        SceneManager.LoadScene(1);
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

    void Defeat()
    {
        ScreensControler.ShowDefeatPanel();
    }

    void NewLevel()
    {
        UserDataControler.SaveData(userData);
        ScreensControler.ShowNewLevelPanel();
    }
    void Step()
    {
        List<Point> combinatedPoints = CombinationsControler.SearchCombinations();
        UserLevel.AddExpirence(ConvertToExpControler.Convert(combinatedPoints));
        SwipeLevel.AddPointsToSwipeLevel();
        if(combinatedPoints.Count != 0) Platform.DeletePointsCombinations(combinatedPoints);
        CreateCurrentElement();
    }
    void CreateCurrentElement()
    {
        currentElement = Instantiate(elementPrefab, currentPos);
    }

    private void OnDestroy()
    {
        SwipeDetector.OnSwipe -= OnSwipe;
        UserLevel.UserDefeat -= Defeat;
        UserLevel.UserNewLevel -= NewLevel;
        SaveUserData();
    }
}
