using System.Collections;
using System.Collections.Generic;
using Controlers;
using ScriptableObjects.UserPersons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChosePersonCore : MonoBehaviour
{
    private UserDataControler UserDataControler;
    private UserPersonsListScrObj UserPersonsListScrObj;
    void Start()
    {
        
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
