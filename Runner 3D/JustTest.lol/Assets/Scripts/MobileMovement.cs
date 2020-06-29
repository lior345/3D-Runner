using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float RunSpeed;
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField] bool detectSwipeOnlyAfterRelease = false;
    [SerializeField]
    float minDistanceForSwipe = 20f;

    bool alive = true;
    bool isgrounded = true;

    Vector3 goalPosition;

    Rigidbody rb;

    public GameObject replay;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
        if (alive)
        {
            transform.Translate(0, 0, RunSpeed * Time.deltaTime);//forward

            if (transform.position.x < 1)
            {

                if (Input.GetKeyDown(KeyCode.D))//right
                {
                    goalPosition.x = transform.position.x + 1;
                    StartCoroutine(RightSlide());
                }
            }

            if (transform.position.x > -1)//left
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    goalPosition.x = transform.position.x - 1;
                    StartCoroutine(LeftSlide());
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))//jump
            
            {
                if (isgrounded)
                {
                    rb.velocity = new Vector3(0, jumpForce, 0);
                    isgrounded = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            alive = false;
            replay.SetActive(true);
            anim.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isgrounded = true;
    }


    IEnumerator RightSlide()
    {
        while (transform.position.x < goalPosition.x)
        {
            transform.position = Vector3.Lerp(transform.position, right.position, 1);
            yield return new WaitForSeconds(.0001f);
            RightSlide();
        }
    }
    IEnumerator LeftSlide()
    {
        while (transform.position.x > goalPosition.x)
        {
            transform.position = Vector3.Lerp(transform.position, left.position, 1);
            yield return new WaitForSeconds(.0001f);
            LeftSlide();
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
            }
            else
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
            }
            fingerUpPosition = fingerDownPosition;
        }
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
