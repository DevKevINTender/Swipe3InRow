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
                    for (int i = 0; i <= 4; i++)
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
                    if (CheckFreeRowPoint())
                    {
                        DisplacementElements();
                        _platformPoints[_currentRow,0].AddElement(newElement);
                        _statusPoints[_currentRow, 0] = 1;
                        return true;
                    }
                    break;
            }
            return false;
        }

        public void DisplacementElements()
        {
            for (int i = 4; i >= 1; i--)
            {
                if (_statusPoints[_currentRow, i-1] == 1)
                {
                    Debug.Log("tetst");
                    _platformPoints[_currentRow,i].GetAnotherPoint(_platformPoints[_currentRow, i-1]);
                    if (_statusPoints[_currentRow, i] == 0)
                    {
                        _statusPoints[_currentRow, i] = 1;
                    }
                    
                }
            }
        }
        public bool CheckFreeRowPoint()
        {
            return (_statusPoints[_currentRow, 4] == 1) ? false : true;
        }

        
        public void ChangeCurrentRow(string side)
        {
            CalculateSteps(side);
            _currentEndicate.transform.localPosition = new Vector2(0, RowStart + _currentRow * 150);
            Debug.Log("Current row : " + _currentRow);
        }

        public void CalculateSteps(string side)
        {
            const int step = 1; // шаг по строкам
            if (_currentRow + step > 4 && side == "up")
            {
                _currentRow -= 4 * step;
                return;
            }

            if (_currentRow + step <= 4 && side == "up")
            {
                _currentRow += step;
                return;
            }    
                
            if (_currentRow - step < 0 && side == "down")
            {
                _currentRow += 4 * step;
                return;
            }

            if (_currentRow - step >= 0 && side == "down")
            {
                _currentRow -= step;
                return;
            }
        }

        public void FillFreePoints()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    if(_statusPoints[i, j] == 0) continue;
                    
                    int freej = -1;
                    for (int k = j; k >= 0; k--)
                    {
                        if (_statusPoints[i, k] == 0)
                        {
                            freej = k;
                        }
                    }

                    if (freej != -1)
                    {
                        _platformPoints[i,freej].GetAnotherPoint(_platformPoints[i, j]);
                        _statusPoints[i, freej] = 1;
                        _statusPoints[i, j] = 0;
                    }
                    
                }
            }
        }

        public void DestroyPanel()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    Object.Destroy(_platformPoints[i,j]._pointObject);
                }
            }
            Object.Destroy(_currentEndicate);
        }
        
        public void DeletePointsCombinations(List<Point> elementsFields)
        {
            Debug.Log($"delete count: {elementsFields.Count}");
            foreach (Point item in elementsFields)
            {
                int i = item.GetRow();
                int j = item.GetCol();
                _statusPoints[i, j] = 0;
                item.DestroyElement();
            }
        }
    }
}
