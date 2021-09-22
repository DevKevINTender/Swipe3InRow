namespace SwipeToCompleteThreeInRow
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Platform
    {
        public int _rowCount;
        public int _colCount;

        public Point[,] _platformPoints;
        private Transform _platformParent;
        private GameObject _currentEndicatePrefab;
        private GameObject _currentEndicate;

        public int[,] _statusPoints; // 0 - free

        private int _currentRow = 0;

        public const int RowStart = -300;
        public const int ColStart = -300;

        
        public Platform(int rowCount, int colCount, Transform platformParent)
        {
            this._rowCount = rowCount;
            this._colCount = colCount;
            this._platformParent = platformParent;
            this._currentEndicatePrefab = Resources.Load("Prefabs/CurrentIndicate", typeof(GameObject)) as GameObject;
            
            _statusPoints = new int[rowCount,colCount];
            _platformPoints = new Point[rowCount,colCount];
            Vector3 instPos = new Vector2(0, RowStart + _currentRow * 150);
            _currentEndicate = Object.Instantiate(_currentEndicatePrefab,_platformParent);
            _currentEndicate.transform.localPosition = instPos;
            
            CreateFields();
        }

        
        void CreateFields()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    _platformPoints[i,j] = new Point(i,j, _platformParent);
                }
            }
        }
        
        
        public bool AddElementToPoint(string side, Element newElement)
        {
            switch (side)
            {
                case "left":
                    for (int i = 2; i <= 4; i++)
                    {
                        if (_statusPoints[_currentRow, i] == 0)
                        {
                            _platformPoints[_currentRow,i].AddElement(newElement);
                            _statusPoints[_currentRow, i] = 1;
                            return true;
                        }
                    }
                    break;
                case "right":
                    for (int i = 2; i >= 0; i--)
                    {
                        if (_statusPoints[_currentRow, i] == 0)
                        {
                            _platformPoints[_currentRow,i].AddElement(newElement);
                            _statusPoints[_currentRow, i] = 1;
                            return true;
                        }
                    } 
                    break;
            }
            return false;
        }

        
        public void ChangeCurrentRow(string side)
        {
            const int step = 1; // шаг по строкам
            if (_currentRow + step <= 4 && side == "up") _currentRow += step;
            if (_currentRow - step >= 0 && side == "down") _currentRow -= step;
            _currentEndicate.transform.localPosition = new Vector2(0, RowStart + _currentRow * 150);
            Debug.Log("Current row : " + _currentRow);
        }

        
        
        
        public void DeletePointsCombinations(List<Point> elementsFields)
        {
            Debug.Log($"delete count: {elementsFields.Count}");
            foreach (Point item in elementsFields)
            {
                int i = item.GetRow();
                int j = item.GetCol();
                _statusPoints[i, j] = 0;
                item.Destroyelement();
            }
        }
    }
}
