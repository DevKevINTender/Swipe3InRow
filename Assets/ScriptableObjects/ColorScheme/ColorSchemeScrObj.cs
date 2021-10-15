using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.ColorScheme
{
    [CreateAssetMenu(fileName = "ColorChemeS0", menuName = "ScriptableObjects/Create ColorChemeS0", order = 0)]
    public class ColorSchemeScrObj : ScriptableObject
    {
        public  List<Color> ColorList = new List<Color>();
    }
}