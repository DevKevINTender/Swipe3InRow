using System.Collections.Generic;
using ScriptableObjects.ColorScheme;
using SwipeToCompleteThreeInRow.ColorScheme;
using UnityEngine;

namespace Controlers
{
    public class ColorSchemeControler : MonoBehaviour
    {
        [SerializeField]
        private List<SetItemColor> SetColorItems = new List<SetItemColor>();
        
        public void SetColors(ColorSchemeScrObj colorScheme)
        {
            SetColorItems.Clear();
            SetColorItems.AddRange(FindObjectsOfType<SetItemColor>());
            foreach (SetItemColor item in SetColorItems)
            {
                item.SetColor(colorScheme.ColorList);
            }
        }
    }
}