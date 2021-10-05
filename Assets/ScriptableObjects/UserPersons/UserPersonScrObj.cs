using UnityEngine;

namespace ScriptableObjects.UserPersons
{
    [CreateAssetMenu(fileName = "UserPersonScrObj", menuName = "ScriptableObjects/Create UserPersonsScr", order = 0)]
    public class UserPersonScrObj: ScriptableObject
    {
        public GameObject PersonObject;
        public GameObject PersonType;
        public GameObject PersonView;
        public int countBonus;
        public int requiredLevel;
        public int id;
    }
}