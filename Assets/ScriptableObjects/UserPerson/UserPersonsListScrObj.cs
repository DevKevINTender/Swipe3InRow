using System.Collections.Generic;
using SwipeToCompleteThreeInRow;
using UnityEngine;

namespace ScriptableObjects.UserPersons
{
    [CreateAssetMenu(fileName = "UserPersonsListScr", menuName = "ScriptableObjects/Create UserPersonsListScr", order = 0)]
    public class UserPersonsListScrObj : ScriptableObject
    {
        [SerializeField] public List<UserPersonScrObj> userLevels;
    }
}