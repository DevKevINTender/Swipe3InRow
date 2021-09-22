using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects.SwipeLevel
{
    [CreateAssetMenu(fileName = "SwipeLevels", menuName = "ScriptableObjects/Create SwipeLevelsSO", order = 0)]
    public class SwipeLevelsSO : ScriptableObject
    {
        public List<SwipeLevelSO> swipeLevels = new List<SwipeLevelSO>();
    }
}