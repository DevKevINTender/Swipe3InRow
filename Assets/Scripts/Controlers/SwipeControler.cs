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
        public bool SwipeSolution(SwipeDetector.SwipeData swipeData, Element currentElement)
        {
            switch (swipeData.Direction)
            {
                case SwipeDetector.SwipeDirection.Up:
                    if(swipeData.Side == SwipeDetector.SwipeSide.RightSide) _platform.ChangeCurrentRow("up");
                    _platform.ChangeCurrentRow("up");
                    break;
                case SwipeDetector.SwipeDirection.Down:
                    if(swipeData.Side == SwipeDetector.SwipeSide.RightSide) _platform.ChangeCurrentRow("down");
                    _platform.ChangeCurrentRow("down");   
                    break;
                case  SwipeDetector.SwipeDirection.Left:
                    if (_platform.AddElementToPoint("left", currentElement)) return true;
                    break;
                case  SwipeDetector.SwipeDirection.Right:
                    if (_platform.AddElementToPoint("right", currentElement)) return true;
                    break;
            } 
            return false;
        }
    }
}