using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObjects/Create LevelSO", order = 1)]
    public class LevelSO: ScriptableObject
    {
        public int level;
        public float needExp;
        public float acceleration;
        public int startPercent;
    }
}