using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects.UserPersons
{
    [CreateAssetMenu(fileName = "UserPersonScrObj", menuName = "ScriptableObjects/Create UserPersonsScr", order = 0)]
    public class UserPersonScrObj: ScriptableObject
    {
        public Sprite PersonSprite;
        public int countBonus;
        public int requiredLevel;
        public int id;
    }
}