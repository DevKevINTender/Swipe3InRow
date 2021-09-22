using UnityEngine;

namespace ScriptableObjects.SwipeLevel
{
    [CreateAssetMenu(fileName = "SwipeLvlS0", menuName = "ScriptableObjects/Create SwipeLvlSO", order = 1)]
    public class SwipeLevelSO: ScriptableObject
    {
        public int level;
        public float needPoints;
    }
}