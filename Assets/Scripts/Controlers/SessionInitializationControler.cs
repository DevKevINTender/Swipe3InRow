using ScriptableObjects.GameTier;
using SwipeToCompleteThreeInRow;
using UnityEngine;

namespace Controlers
{
    public class SessionInitializationControler : MonoBehaviour
    {
        [SerializeField]
        private Platform Platform;
        public Transform Canvas;

        private GameTierScrObj GameTier;

        // generate new scene by parametrs
        public void SessionInitialization(GameTierScrObj gameTier)
        {
            Platform = new Platform(5,5, Canvas);
            this.GameTier = gameTier;
        }

        public Platform GetPlatform()
        {
            return this.Platform;
        }

        public void DestroyPanel()
        {
          
        }
        
    }
}