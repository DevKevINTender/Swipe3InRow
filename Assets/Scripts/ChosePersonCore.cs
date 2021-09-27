using System.Collections;
using System.Collections.Generic;
using Controlers;
using Models;
using Presenters;
using ScriptableObjects.UserPersons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChosePersonCore : MonoBehaviour
{
    [SerializeField]
    private UserDataControler UserDataControler;
    [SerializeField]
    private UserPersonsListScrObj UserPersonsListScrObj;

    private UserDataModel UserDataModel;
    public GameObject PersonPanelPb;
    public Transform personPanelPos;

    public PersonPanel currentPersonPanel;
    void Start()
    {
        UserDataControler = new UserDataControler();
        UserDataModel = UserDataControler.LoadData();
        GeneratePersonPanels();
    }

    void GeneratePersonPanels()
    {
        foreach (UserPersonScrObj item in UserPersonsListScrObj.userLevels)
        {
           PersonPanel personPanel = Instantiate(PersonPanelPb, personPanelPos).GetComponent<PersonPanel>();
           personPanel.CreatePersonPanel(item, UserDataModel, this);

           if (UserDataModel.currentPerson == item.id)
           {
               currentPersonPanel = personPanel;
           }
           
        }
        
    }

    public void ActivateNewPersonaPanel(PersonPanel newPersonPanel)
    {
        currentPersonPanel.Diactivate();
        currentPersonPanel = newPersonPanel;
        UserDataModel.currentPerson = currentPersonPanel.id;
        Debug.Log(currentPersonPanel.id);
        currentPersonPanel.Activate();
        UserDataControler.SaveData(UserDataModel);
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
