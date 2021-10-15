using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.GameTier
{
    [CreateAssetMenu(fileName = "GameTierListSO", menuName = "ScriptableObjects/Create GameTierListSO", order = 0)]
    public class GameTierListScrObj : ScriptableObject
    {
        public List<GameTierScrObj> gameTierList;
    }
}