


using System.Collections.Generic;

namespace SwipeToCompleteThreeInRow
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class Element: MonoBehaviour
    {
        public List<Color> listColors = new List<Color>();
        [SerializeField]
        private Image _elementImage;
        private Color _elementColor;

        private void Start()
        {
            int rand = Random.Range(0, listColors.Count);
            _elementColor = listColors[rand];
            _elementImage.color = _elementColor;
        }

        public Color GetElementColor()
        {
            return _elementColor;
        }

        public void SetToFieldPosition(Transform parent)
        {
            gameObject.transform.position = parent.transform.position;
            gameObject.transform.SetParent(parent);
        }
        
    }
    
}