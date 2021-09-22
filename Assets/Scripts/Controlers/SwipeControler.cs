using SwipeToCompleteThreeInRow;

namespace Controlers
{
    public class SwipeControler
    {
        private Platform _platform;
        
        public SwipeControler(Platform platform)
        {
            this._platform = platform;
        }
        public bool SwipeSolution(SwipeData swipeData, Element currentElement)
        {
            switch (swipeData.Direction)
            {
                case SwipeDirection.Up:
                    _platform.ChangeCurrentRow("up");
                    break;
                case SwipeDirection.Down:
                    _platform.ChangeCurrentRow("down");   
                    break;
                case  SwipeDirection.Left:
                    if (_platform.AddElementToPoint("left", currentElement)) return true;
                    break;
                case  SwipeDirection.Right:
                    if (_platform.AddElementToPoint("right", currentElement)) return true;
                    break;
            } 
            return false;
        }
    }
}