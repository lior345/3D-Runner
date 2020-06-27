using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody rb;
    bool alive = true;
    public GameObject replay;
    [SerializeField] float jumpForce;
    bool isgrounded=true;
    [SerializeField] float RunSpeed;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, RunSpeed * Time.deltaTime);//forward
            transform.position = new Vector3(Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);//sideways          if >&< 1/-1 - tranformpostitionx+axis
            /*

            if (Input.touches.Length > 0) 
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    touchstartPos = new Vector2;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    touchstartPos = new Vector2;
                }
            }

    */



          if(Input.GetKeyDown(KeyCode.Space))
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
        if(other.gameObject.CompareTag("Obstacle"))
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
}
