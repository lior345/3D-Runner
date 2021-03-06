﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float nextLane;
    private float lerpSpeed = 5;
    private bool isgrounded = true;
    private Vector3 nextPos;
    private Rigidbody rb;
    private float actualSpeed;//calculated by the pre-determined speed*speed multiplier from menu
    
    [SerializeField] float jumpForce;
    [SerializeField] float runSpeed;
    
    public GameObject replay;//When failing- a replay option will appear
    public Transform cameraTransform;
    public TouchManager touchManager;
    public bool alive = true;
    public float speedMultiplier = 1;
    public int doesCameraFollow = 0;

    private void Start()
    {
        nextLane=0;//starting in the middle
        rb = GetComponent<Rigidbody>();
        actualSpeed = runSpeed;
    }
private void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, actualSpeed * Time.deltaTime);//forward movement*speed Multipier from menu
            transform.position = Vector3.Lerp(transform.position, new Vector3(nextPos.x,transform.position.y,transform.position.z), lerpSpeed * Time.deltaTime);//gradual side movement
            
            cameraTransform.position = new Vector3(doesCameraFollow * transform.position.x, 3f, transform.position.z - 2.5f);//camera Movement

            #region Movement Inputs
            if (Input.GetKeyDown(KeyCode.D)||touchManager.swipeRight)//move right
            {
                RightMove();
            }
            if (Input.GetKeyDown(KeyCode.A) || touchManager.swipeLeft)//move left
            {
                LeftMove();
            }
            if (Input.GetKeyDown(KeyCode.Space) || touchManager.swipeUp)//jump
            {
                if (isgrounded)
                {
                    rb.velocity = new Vector3(0, jumpForce, 0);
                    isgrounded = false;
                }
            }
            #endregion
        }
    }
    public void SetSpeedMultiplier(float multiplier)
    {
        actualSpeed = runSpeed * multiplier;
    }
    private void LeftMove()//Left Movement Check
    {
        nextLane--;
        if(nextLane==-2)
        {
            nextLane = -1;
        }
        nextPos =new Vector3 (nextLane, transform.position.y, transform.position.z);
    }
    private void RightMove()//Right Movement Check
    {
        nextLane++;
        if (nextLane ==2)
        {
            nextLane = 1;
        }
        nextPos = new Vector3(nextLane, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)//ground check
    {
        isgrounded = true;
    }
    private void OnTriggerEnter(Collider other)//Triggers Check- Obstacles / Collectables / finishline 
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            alive = false;
            Time.timeScale = 0;
            replay.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Crystal"))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 50);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Coin"))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 10);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            alive = false;
            Time.timeScale = 0;
            replay.gameObject.SetActive(true);
        }
    }
}
