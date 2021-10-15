


using System.Collections.Generic;

namespace SwipeToCompleteThreeInRow
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class Element: MonoBehaviour
    {
        [SerializeField] 
        private Animation _animation;
        [SerializeField]
        private Image _elementImageBack;
        [SerializeField]
        private Image _elementImageFront;
        public List<Color> listColors = new List<Color>();
   
        private Color _elementColor;

        private void Start()
        {
            int rand = Random.Range(0, listColors.Count);
            _elementColor = listColors[rand];
            _elementImageBack.color = _elementColor;
        }

        public void CreateElement(Sprite imageSprite)
        {
            _elementImageFront.sprite = imageSprite;
        }
        public Color GetElementColor()
        {
            return _elementColor;
        }

        public void DestroyElement()
        {
            _animation.Play("PersonAnimDestroy");
            StartCoroutine(Destroy());
        }
        
        public void SetToFieldPosition(Transform parent)
        {
            StartCoroutine(Move(parent));
        }
        IEnumerator Destroy() 
        {
            while (_animation.IsPlaying("PersonAnimDestroy"))
            {
                yield return null;     
            }
            Destroy(gameObject);
            
        }
        IEnumerator Move(Transform parent) 
        {
            float timePassed = 0;
            float distance = Vector3.Distance(gameObject.transform.position, parent.transform.position);
            gameObject.transform.SetParent(parent);
            while (gameObject.transform.localPosition != parent.transform.position)
            {
                gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, parent.transform.position ,Time.deltaTime*30*distance);
                yield return null;     
            }
            
        }
    }
    
}