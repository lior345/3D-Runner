using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{    
    
    
    [SerializeField] float jumpForce;
    [SerializeField] float RunSpeed;

    bool alive = true;
    bool isgrounded=true;

    Rigidbody rb;

    public GameObject replay;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, RunSpeed * Time.deltaTime);//forward

            if(transform.position.x<1)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                }
            }
            if (transform.position.x >-1)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
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
