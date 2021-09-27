using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace Models
{
    [SerializeField]
    [XmlRoot]
    public class UserDataModel
    {
        [XmlArray] public List<int> boughtPersons;
        [XmlArray] public List<int> curentBonuses;
        public int currentPerson = 0;
        public int currentUserLevel = 0;
    }
}