using System.Collections.Generic;
using SwipeToCompleteThreeInRow;
using UnityEngine;

namespace Controlers
{
    public class CombinationsControler
    {
        private Platform _platform;

        public CombinationsControler(Platform platform)
        {
            this._platform = platform;
        }
        public List<Point> SearchCombinations()
        {
            List<Point> combinationPoints = new List<Point>();
            
            for (int i = 0; i < this._platform._rowCount; i++)
            {
                for (int j = 0; j < this._platform._rowCount; j++)
                {
                    if (this._platform._statusPoints[i, j] != 0)
                    {
                        List<Point> horizontalCheck = CheckHorisontal(i, j);
                        List<Point> verticalCheck = CheckVertical(i, j);
                        List<Point> box2x2Check = CheckBox(i, j);

                        if (horizontalCheck.Count >= 3)
                        {
                            combinationPoints.AddRange(CheckToUnique(combinationPoints ,horizontalCheck));
                        }

                        if (verticalCheck.Count >= 3)
                        {
                            combinationPoints.AddRange(CheckToUnique(combinationPoints ,verticalCheck));
                        }
                        combinationPoints.AddRange(CheckToUnique(combinationPoints ,box2x2Check));
                        Debug.Log($"combinations found {combinationPoints.Count}");
                        
                    }
                }
            }

            return combinationPoints;
        }

        List<Point> CheckToUnique(List<Point> combinationPoints, List<Point> newPointsToAdd)
        {
            List<Point> uniquePoints = new List<Point>();
            foreach (Point point in newPointsToAdd)
            {
                if (!combinationPoints.Contains(point))
                {
                    uniquePoints.Add(point);
                }
            }

            return uniquePoints;
        }

        List<Point> CheckBox(int row, int col)
        {
            List<Point> fieldsWithElements = new List<Point>();
            
            for (int i = row; i <= row+1; i++)
            {
                for (int j = col; j <= col+1; j++)
                {
                    if ( i < _platform._rowCount && j < _platform._colCount && _platform._statusPoints[i, j] != 0)
                    {
                        if (CompareElementsColor(row,col,i,j))
                        {
                            fieldsWithElements.Add(_platform._platformPoints[i, j]);
                        }
                    }
                } 
            }

            if (fieldsWithElements.Count != 4)
            {
                fieldsWithElements.Clear();
            }
            
            return fieldsWithElements;
        }
        List<Point> CheckVertical(int row, int col)
        {
            List<Point> fieldsWithElements = new List<Point>();
            
            fieldsWithElements.Add(_platform._platformPoints[row,col]);
            
            for (int i = row+1; i < _platform._rowCount; i++)
            {
                if (_platform._statusPoints[i, col] == 0)
                {
                    return fieldsWithElements;
                }
                else
                {
                    if (_platform._platformPoints[row, col].GetElementColor() == _platform._platformPoints[i, col].GetElementColor())
                    {
                        fieldsWithElements.Add(_platform._platformPoints[i, col]);
                    }
                    else
                    {
                        return fieldsWithElements;
                    }
                }
            }
            return fieldsWithElements;
        }
        
        
        List<Point> CheckHorisontal(int row, int col)
        {
            List<Point> fieldsWithElements = new List<Point>();
            
            fieldsWithElements.Add(_platform._platformPoints[row,col]);
            
            for (int j = col+1; j < _platform._colCount; j++)
            {
                if (_platform._statusPoints[row, j] == 0)
                {
//                    Debug.Log($"Пустое поле {row} : {j}");
                    return fieldsWithElements;
                }
                else
                {
                    if (_platform._platformPoints[row, col].GetElementColor() == _platform._platformPoints[row, j].GetElementColor())
                    {
                        fieldsWithElements.Add(_platform._platformPoints[row, j]);
                    }
                    else
                    {
  //                      Debug.Log($"Не соответвие цвета {row} : {j}");
                        return fieldsWithElements;
                    }
                }
            }
    //        Debug.Log("Нет доступных полей");
            return fieldsWithElements;
        }

        bool CompareElementsColor(int firsRow, int firsCol, int secondRow, int secondCol)
        {
            return (_platform._platformPoints[firsRow, firsCol].GetElementColor() ==
                _platform._platformPoints[secondRow, secondCol].GetElementColor());
        }
    }
}