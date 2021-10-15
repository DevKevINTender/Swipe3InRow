using System.Collections;
using System.Collections.Generic;
using Controlers;
using Models;
using ScriptableObjects.ColorScheme;
using ScriptableObjects.GameTier;
using ScriptableObjects.UserPersons;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuCore : MonoBehaviour
{
    [SerializeField]
    private ColorSchemeControler ColorSchemeControler;
    [SerializeField]
    private GameTierControler GameTierControler;
    
    private UserDataControler UserDataControler;
    [SerializeField]
    private UserPersonsListScrObj UserPersonsListScrObj;
    private UserDataModel UserData;
    private GameTierScrObj GameTier;
    [SerializeField]
    private RectTransform currentPersonPos;
    [SerializeField]
    private Image currentPersonImage;
    private GameObject curerntPersonObj;
    [SerializeField] 
    private Text userLevelText;
    void Start()
    {
        UserDataControler = new UserDataControler();
        UserData = UserDataControler.LoadData();
        currentPersonImage.sprite =
            UserPersonsListScrObj.userLevels[UserData.currentPerson].PersonSprite;
        
        GameTier = GameTierControler.GetCurrentGameTier(UserData);
        ColorSchemeControler.SetColors(GameTier.colorCheme);

        userLevelText.text = $"{UserData.currentUserLevel}";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSession()
    {
        SceneManager.LoadScene(1);
    }

    public void loadChoosePerson()
    {
        SceneManager.LoadScene(2);
    }

   
}
