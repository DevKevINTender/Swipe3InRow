using System.Collections.Generic;
using SwipeToCompleteThreeInRow;
using SwipeToCompleteThreeInRow.Person;
using UnityEngine;

namespace Controlers
{
    public class ConvertToExpControler
    {
        private float resultexpirence;
        private ScriptableObject UserPersons;
        private IPerson currentPerson;
        public ConvertToExpControler(IPerson currentPerson)
        {
            this.currentPerson = currentPerson;
        }



        public float Convert(List<Point> points)
        {
            resultexpirence = currentPerson.CombinationsCalculateExpirence(points);
            //resultexpirence = points.Count;
            return resultexpirence;
        }
    }
}