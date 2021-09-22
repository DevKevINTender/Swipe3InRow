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
        private Image swipeLevelBar;

        private int currentLevel;
        private int currentPoints;
        private float needPoints;

        private void Awake()
        {
            SwipeDetectorService.OnSwipe += OnSwipe;
            needPoints = SwipeLevelSo.swipeLevels[currentLevel].needPoints;
        }

        void OnSwipe(SwipeData swipeData)
        {
            if (swipeData.Direction == SwipeDirection.Left || swipeData.Direction == SwipeDirection.Right)
            {
                AddPointsToSwipeLevel();
            }
        }

        void AddPointsToSwipeLevel()
        {
            currentPoints++;
            if (currentPoints >= needPoints)
            {
                SwipeLevelUp();
            }
        }

        void SwipeLevelUp()
        {
            if (currentLevel < SwipeLevelSo.swipeLevels.Count)
            {
                currentLevel++;
                swipeLevelImage.fillAmount = 0.2f * currentLevel;
                currentPoints = 0;
            }
            
        }

        private void Update()
        {
            swipeLevelBar.fillAmount = currentPoints / needPoints;
        }

        private void OnDestroy()
        {
            SwipeDetectorService.OnSwipe -= OnSwipe;
        }
    }
}