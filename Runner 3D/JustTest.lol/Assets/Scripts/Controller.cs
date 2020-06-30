using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float nextLane;
    private bool alive = true;
    private bool isgrounded = true;
    private Vector3 nextPos;
    private Rigidbody rb;

    [SerializeField] float jumpForce;
    [SerializeField] float RunSpeed;

    public GameObject replay;
    public Animator anim;

    private void Start()
    {
        Time.timeScale = 1;
        nextLane=0;
        rb = GetComponent<Rigidbody>();
    }
private void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, RunSpeed * Time.deltaTime);//forward

            if (Input.GetKeyDown(KeyCode.D))
            {
                RightMove();
                transform.position = Vector3.Lerp(transform.position, nextPos, 30);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeftMove();
                transform.position = Vector3.Lerp(transform.position, nextPos, 30);
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
        else Time.timeScale = 0;
    }
    private void LeftMove()
    {
        nextLane--;
        if(nextLane==-2)
        {
            nextLane = -1;
        }
        nextPos =new Vector3 (nextLane, transform.position.y, transform.position.z);
    }
    private void RightMove()
    {
        nextLane++;
        if (nextLane ==2)
        {
            nextLane = 1;
        }
        nextPos = new Vector3(nextLane, transform.position.y, transform.position.z);

    }
    private void OnCollisionEnter(Collision collision)
    {
        isgrounded = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            alive = false;
            replay.SetActive(true);
        }
    }
}
