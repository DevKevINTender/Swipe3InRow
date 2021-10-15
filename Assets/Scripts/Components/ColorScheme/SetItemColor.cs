using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwipeToCompleteThreeInRow.ColorScheme
{
    public class SetItemColor : MonoBehaviour
    {
        [SerializeField] private int itemId;
        [SerializeField] private Image colorImage;

        public void SetColor(List<Color> colorList)
        {
            colorImage.color = colorList[itemId];
        }
        
    }
}