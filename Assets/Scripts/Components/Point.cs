namespace SwipeToCompleteThreeInRow
{
    using  UnityEngine;
    public class Point
    {
        private GameObject _pointObject;
        private Element _element;
        private Transform _parent;
        private int _row;
        private int _col;

        private const int ScreenStep = 150;

        public Point(int row, int col, Transform parent)
        {
            this._row = row;
            this._col = col;
            this._parent = parent;
            
            CreateField();
        }

        public Color GetElementColor()
        {
            return _element.GetElementColor();
        }
        void CreateField()
        {
            Vector3 instPos = new Vector2(Platform.ColStart + _col * ScreenStep, Platform.RowStart + _row * ScreenStep);
            GameObject pointPrefab = Resources.Load("Prefabs/PointPrefab", typeof(GameObject)) as GameObject;
            _pointObject = Object.Instantiate(pointPrefab,_parent.transform);
            _pointObject.transform.localPosition = instPos;
        }

        public int GetCol()
        {
            return _col;
        }
        public int GetRow()
        {
            return _row;
        }
        public void AddElement(Element element)
        {
            _element = element;
            _element.SetToFieldPosition(_pointObject.transform);
        }

        public void Destroyelement()
        {
            GameObject.Destroy(_element.gameObject);
            _element = null;
        }

    }
}