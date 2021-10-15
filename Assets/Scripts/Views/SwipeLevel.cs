using System;
using System.Collections.Generic;
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
        [SerializeField]
        private List<Color> listColor = new List<Color>();
        private void Awake()
        {
            needPoints = SwipeLevelSo.swipeLevels[currentLevel];
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

        public int GetSwipeLevel()
        {
            return currentLevel;
        }
        void SwipeLevelUp()
        {
            if (currentLevel < SwipeLevelSo.swipeLevels.Count-1)
            {
                swipeLevelImage.color = listColor[currentLevel];
                currentLevel++;
                needPoints = SwipeLevelSo.swipeLevels[currentLevel];
                swipeLevelText.text = $"{currentLevel}";
                currentPoints = 0;
            }
        }
    }
}