using Models;
using ScriptableObjects.UserPersons;
using SwipeToCompleteThreeInRow;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters
{
    public class PersonPanel : MonoBehaviour
    {
        [SerializeField]
        private Image statusIndicate;
        [SerializeField]
        private Text requiredLevel;
        [SerializeField]
        private Text bonus;
        [SerializeField]
        private Text personName;
        [SerializeField] 
        private Image hideLevel;

        [SerializeField] 
        private Transform personPos;
        public int id;
        private UserDataModel UserDataModel;
        private ChosePersonCore ChosePersonCore;

        private int UserLevel;
        private UserPersonScrObj UserPersonScrObj;
        private int PanelStatus; // 0 - not availabale 1 - availabe 2 - active

        [SerializeField]
        private Element personPb;

        private Element personObj;

        public void CreatePersonPanel(UserPersonScrObj userPersonScrObj, UserDataModel userDataModel,ChosePersonCore chosePersonCore )
        {
            this.UserPersonScrObj = userPersonScrObj;
            this.ChosePersonCore = chosePersonCore;
            this.id = UserPersonScrObj.id;
            requiredLevel.text = $"{UserPersonScrObj.requiredLevel}";
            bonus.text = $"+{UserPersonScrObj.countBonus}%";
            this.UserDataModel = userDataModel;

            personObj = Instantiate(personPb, personPos);
            personObj.CreateElement(userPersonScrObj.PersonSprite);
            
            DefineStatus();
        }

        public void DefineStatus()
        {
            if (UserPersonScrObj.id == UserDataModel.currentPerson)
            {
                PanelStatus = 2;
                Debug.Log($"id: {UserPersonScrObj.id}" );
                Debug.Log($"person {UserDataModel.currentPerson}");
                Debug.Log("test3");
            }
            else
            {
                PanelStatus = 1;
                statusIndicate.color = new Color32(255,255,255,50);
                Debug.Log("test");
                if (UserPersonScrObj.requiredLevel > UserDataModel.currentUserLevel)
                {
                    Debug.Log("test2");
                    hideLevel.gameObject.SetActive(true);
                    PanelStatus = 0;
                }
                
            }
        }

        public void Activate()
        {
            PanelStatus = 2;
            statusIndicate.color = new Color32(255,255,255,255);
        }

        public void Diactivate()
        {
            PanelStatus = 1;
            statusIndicate.color = new Color32(255,255,255,50);
        }
        public void PanelChose()
        {
            switch (PanelStatus)
            {
                case 0:
                {
                    break;   
                }
                case 1:
                {
                    ChosePersonCore.ActivateNewPersonaPanel(this);
                    break;
                }
                case 2:
                {
                    break;
                }
            }
        }
    }
}