using System.Collections;
using System.Collections.Generic;
using Controlers;
using Models;
using Presenters;
using ScriptableObjects.GameTier;
using ScriptableObjects.UserPersons;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChosePersonCore : MonoBehaviour
{
    [SerializeField]
    private GameTierControler GameTierControler;
    [SerializeField]
    private ColorSchemeControler ColorSchemeControler;
    [SerializeField]
    private UserDataControler UserDataControler;
    [SerializeField]
    private UserPersonsListScrObj UserPersonsListScrObj;

    [SerializeField] 
    private Text userLevelText;
    private UserDataModel UserData;
    public GameObject PersonPanelPb;
    public Transform personPanelPos;
    private GameTierScrObj GameTier;

    public PersonPanel currentPersonPanel;
    void Start()
    {
        UserDataControler = new UserDataControler();
        UserData = UserDataControler.LoadData();
        GameTier = GameTierControler.GetCurrentGameTier(UserData);
        ColorSchemeControler.SetColors(GameTier.colorCheme);
        SetUserLevel();
        GeneratePersonPanels();
    }

    void GeneratePersonPanels()
    {
        foreach (UserPersonScrObj item in UserPersonsListScrObj.userLevels)
        {
           PersonPanel personPanel = Instantiate(PersonPanelPb, personPanelPos).GetComponent<PersonPanel>();
           personPanel.CreatePersonPanel(item, UserData, this);

           if (UserData.currentPerson == item.id)
           {
               currentPersonPanel = personPanel;
           }
           
        }
        
    }

    public void SetUserLevel()
    {
        userLevelText.text = $"{UserData.currentUserLevel}";
    }
    public void ActivateNewPersonaPanel(PersonPanel newPersonPanel)
    {
        currentPersonPanel.Diactivate();
        currentPersonPanel = newPersonPanel;
        UserData.currentPerson = currentPersonPanel.id;
        Debug.Log(currentPersonPanel.id);
        currentPersonPanel.Activate();
        UserDataControler.SaveData(UserData);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        
        SceneManager.LoadScene(0);
    }
}
