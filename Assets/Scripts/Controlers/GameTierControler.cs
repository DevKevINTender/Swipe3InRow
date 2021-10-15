using Models;
using ScriptableObjects.GameTier;
using UnityEngine;

namespace Controlers
{
    public class GameTierControler: MonoBehaviour
    {
        [SerializeField]
        private GameTierListScrObj _gameTierListSO;

        private UserDataModel _userData;
        

        public GameTierScrObj GetCurrentGameTier(UserDataModel userData)
        {
            this._userData = userData;
            GameTierScrObj currentGameTier = null;
            int currentLevel = userData.currentUserLevel;
            foreach (GameTierScrObj item in _gameTierListSO.gameTierList)
            {
                if (item.startUserLevel <= currentLevel && currentLevel <= item.endUserLevel)
                {
                    Debug.Log($"{currentLevel} Tier {item.colorCheme}");
                    return item;
                }
            }
            Debug.Log("test");
            return currentGameTier;
        }
    }
}