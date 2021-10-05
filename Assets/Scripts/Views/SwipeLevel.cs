using System;
using ScriptableObjects.SwipeLevel;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters
{
    public class SwipeLevel: MonoBehaviour
    {
        [SerializeField] 
        private SwipeLevelsSO SwipeLevelSo;
        [SerializeField]
        private Image swipeLevelImage;
        [SerializeField] 
        private Text swipeLevelText;
        
        private int currentLevel;
        [SerializeField]
        private int currentPoints;
        private float needPoints;
        private float AllNeedPoints;

        private void Awake()
        {
            needPoints = SwipeLevelSo.swipeLevels[currentLevel];
            AllNeedPoints = SwipeLevelSo.swipeLevels[SwipeLevelSo.swipeLevels.Count-1];
            swipeLevelText.text = $"{currentLevel}";
        }

        public void AddPointsToSwipeLevel()
        {
            currentPoints++;
            if (currentPoints >= needPoints)
            {
                SwipeLevelUp();
            }
        }

        void SwipeLevelUp()
        {
            if (currentLevel < SwipeLevelSo.swipeLevels.Count-1)
            {
                currentLevel++;
                needPoints = SwipeLevelSo.swipeLevels[currentLevel];
                swipeLevelText.text = $"{currentLevel}";
            }
        }

        void SetCurrentSwipeLevelText()
        {
            
        }
        int SumPoints()
        {
            int NeedPoints = 0;
            foreach (var Item in SwipeLevelSo.swipeLevels)
            {
                NeedPoints += Item;
            }
            return NeedPoints;
        }
        private void Update()
        {
            swipeLevelImage.fillAmount = currentPoints / AllNeedPoints;
        }
    }
}