using ScriptableObjects.ColorScheme;
using UnityEngine;

namespace ScriptableObjects.GameTier
{
    [CreateAssetMenu(fileName = "GameTierSO", menuName = "ScriptableObjects/Create GameTierSO", order = 0)]
    public class GameTierScrObj : ScriptableObject
    {
        public int startUserLevel;
        public int endUserLevel;
        public float swipeDecayForce;
        public ColorSchemeScrObj colorCheme;
    }
}