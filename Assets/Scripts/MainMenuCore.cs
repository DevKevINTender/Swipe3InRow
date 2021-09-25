using System.Collections;
using System.Collections.Generic;
using Controlers;
using Models;
using ScriptableObjects.UserPersons;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCore : MonoBehaviour
{
    private UserDataControler UserDataControler;
    [SerializeField]
    private UserPersonsListScrObj UserPersonsListScrObj;
    private UserDataModel _userDataModel;
    [SerializeField]
    private RectTransform currentPersonPos;

    private GameObject currentPersonPb;
    private GameObject curerntPersonObj;
    void Start()
    {
        UserDataControler = new UserDataControler();
        _userDataModel = UserDataControler.LoadData();
        currentPersonPb =
            UserPersonsListScrObj.userLevels[_userDataModel.currentPerson];
        curerntPersonObj = Instantiate(currentPersonPb, currentPersonPos);
        curerntPersonObj.transform.localScale = new Vector3(2,2,2);
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
