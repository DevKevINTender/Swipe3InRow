using System;
using UnityEngine;

namespace Controlers
{
    public class SessionScreensControler : MonoBehaviour
    {
        [SerializeField]
        private GameObject defeatPanel;
        [SerializeField]
        private GameObject newLevelPanel;
        [SerializeField]
        private GameObject menuPanel;

        public void ShowDefeatPanel()
        {
            HideAllPanels();
            defeatPanel.transform.localPosition = new Vector3(0,0,0);
        }

        public void ShowMenuPanel()
        {
            menuPanel.transform.localPosition = new Vector3(0,0,0);
        }

        public void ShowNewLevelPanel()
        {
            HideAllPanels();
            newLevelPanel.GetComponent<Animation>().Play("NewLevelAnim");
        }
        
        public void HideAllPanels()
        {
            menuPanel.transform.localPosition = new Vector3(-1200,0,0);
            defeatPanel.transform.localPosition = new Vector3(-2400,0,0);
        }
    }
}