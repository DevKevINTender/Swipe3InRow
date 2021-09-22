using System;
using System.Collections;
using Models;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters
{
    public class UserLevel : MonoBehaviour
    {
        private int currentLevel;
        [SerializeField]
        private float currentExp;
        [SerializeField]
        private float needExp; // временно
        [SerializeField]
        private Image levelBar;

        private float acceleration;
        
        [SerializeField] private Text levelText;
        [SerializeField] private Text levelScoreText;
        [SerializeField] private Text levelPercentText;

        [SerializeField] private UserLevelsSO levelsSO;
        private UserDataModel UserData;
        
        public delegate void UserHandler();
        public event UserHandler UserDefeat;
        public event UserHandler UserNewLevel;

        public void SetData(UserDataModel userData)
        {
            this.UserData = userData;
            currentLevel = userData.currentUserLevel;
            needExp = levelsSO.userLevels[currentLevel].needExp;
            acceleration = levelsSO.userLevels[currentLevel].acceleration;
            levelText.text = $"{currentLevel}";
        }
        
        public void AddExpirence(float exp)
        {
            currentExp += exp;
            if (currentExp >= needExp)
            {
                currentLevel++;
                UserLevelUp();
            }
        }

        void UserLevelUp()
        {
            if (currentLevel < levelsSO.userLevels.Count)
            {
                UserData.currentUserLevel = currentLevel;
                UserNewLevel?.Invoke();
                //levelText.text = $"{currentLevel}";
                //GetData();
            }

        }

        void UserLevelDefeat()
        {
            UserDefeat?.Invoke();
        }
        
        void updateText()
        {
            float persent = currentExp / needExp;
            levelScoreText.text = $"{Math.Round(currentExp,0)}/{needExp}";
            levelBar.fillAmount = persent;
            levelPercentText.text = $"{Math.Round(persent * 100, 0)}%";
        }

        private void Update()
        {
            if (currentExp < 0)
            {
                UserLevelDefeat();
            }
            else
            {
                currentExp -= ( Time.deltaTime / 10 ) * acceleration;
                updateText();
            }
        }
    }
}