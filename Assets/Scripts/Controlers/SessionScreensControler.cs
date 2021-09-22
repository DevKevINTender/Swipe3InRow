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
            defeatPanel.SetActive(true);
        }

        public void ShowMenuPanel()
        {
            HideAllPanels();
            menuPanel.SetActive(true);
        }

        public void ShowNewLevelPanel()
        {
            HideAllPanels();
            newLevelPanel.SetActive(true);
        }
        
        public void HideAllPanels()
        {
            defeatPanel.SetActive(false);
            newLevelPanel.SetActive(false);
            menuPanel.SetActive(false);
        }
    }
}