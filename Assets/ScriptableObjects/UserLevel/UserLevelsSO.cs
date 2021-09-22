using System.Collections.Generic;

namespace ScriptableObjects
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "UserLevelsSO", menuName = "ScriptableObjects/Create UserLevelsSO", order = 1)]
    public class UserLevelsSO: ScriptableObject
    {
        public List<LevelSO> userLevels = new List<LevelSO>();
    }
    
}