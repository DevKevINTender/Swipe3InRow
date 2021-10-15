using System.Collections.Generic;
using Models;
using Presenters;
using ScriptableObjects.UserPersons;
using SwipeToCompleteThreeInRow;
using UnityEngine;

namespace Controlers
{
    public class ConvertToExpControler
    {
        private SwipeLevel SwipeLevel;
        private UserPersonScrObj UserPerson;
        public ConvertToExpControler(SwipeLevel swipeLevel, UserPersonScrObj userPerson)
        {
            this.UserPerson = userPerson;
            this.SwipeLevel = swipeLevel;
        }
        public float Convert(List<Point> points)
        {
            return points.Count + points.Count * UserPerson.countBonus + points.Count * SwipeLevel.GetSwipeLevel();
        }
    }
}