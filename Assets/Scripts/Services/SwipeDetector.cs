using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeDetector : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static event UnityAction<SwipeData> OnSwipe = delegate { };

    private Vector2 startPosition;
    private Vector2 endPosition;

    private float deltaX;
    private float deltaY;

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = eventData.pointerCurrentRaycast.worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endPosition = eventData.pointerCurrentRaycast.worldPosition;

        deltaX = endPosition.x - startPosition.x;
        deltaY = endPosition.y - startPosition.y;
        
        SwipeDirection direction;
        SwipeSide side;
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > 0)
            {
                direction = SwipeDirection.Right;
            }
            else
            {
                direction = SwipeDirection.Left;
            }
        }
        else
        {
            if (deltaY > 0)
            {
                direction = SwipeDirection.Up;
            }
            else
            {
                direction = SwipeDirection.Down;
            }
        }
        if (endPosition.x > 0)
        {
            side = SwipeSide.RightSide;
        }
        else
        {
            side = SwipeSide.LeftSide;
        }
        Debug.Log(eventData.delta);
        SendSwipe(direction, side);
        
    }
    
    private void SendSwipe(SwipeDirection direction, SwipeSide side)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            Side = side
        };
        OnSwipe?.Invoke(swipeData);
    }
    
    public struct SwipeData
    {
        public SwipeDirection Direction;
        public SwipeSide Side;
    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum SwipeSide
    {
        RightSide,
        LeftSide
    }
    
}
