using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public bool swipeUp, swipeDown, swipeRight, swipeLeft;//static swipe Direction for controller script
    private bool isSwiping;//to make sure no probelms accure at vector2 (0,0) on screen
    private Vector2 startTouch, swipeDirection;

    private void Update()
    {
        swipeUp = swipeDown = swipeRight = swipeLeft = false;//zeroing the static swipe direction

        #region StandAlone  //for computer checks
        if (Input.GetMouseButtonDown(0))
        {
            isSwiping = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isSwiping = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase==TouchPhase.Began)
            {
                isSwiping = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended|| Input.touches[0].phase == TouchPhase.Canceled)
            {
                isSwiping = false;
                Reset();
            }
        }
        #endregion

        #region Direction Calculation
        swipeDirection = Vector2.zero;
        if(isSwiping)
        {
            if(Input.touches.Length>0)
            {
                swipeDirection = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDirection = (Vector2)Input.mousePosition - startTouch;
            }
            if(swipeDirection.magnitude>100)  //swipe minimum
            {
                //direcrion
                float x = swipeDirection.x;
                float y = swipeDirection.y;

                if(Mathf.Abs(x)>Mathf.Abs(y))// left / right
                {
                    if (x < 0) swipeLeft = true;
                    else swipeRight = true;
                }
                else  //  up/down
                {
                    if (y < 0) swipeDown = true;
                    else swipeUp = true;
                }
                Reset();
            }
        }
        #endregion
    }
    private void Reset()//resert the touch values
    {
        startTouch = swipeDirection = Vector2.zero;
        isSwiping = false;
    }
}
