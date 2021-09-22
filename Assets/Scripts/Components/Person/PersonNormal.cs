using System.Collections.Generic;
using UnityEngine;

namespace SwipeToCompleteThreeInRow.Person
{
    public class PersonNormal: MonoBehaviour, IPerson
    {
        public float CombinationsCalculateExpirence(List<Point> points)
        {
            return points.Count;
        }
    }
}