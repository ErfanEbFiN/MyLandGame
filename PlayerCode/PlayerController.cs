using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Get Axis
    private Rigidbody _rigidbody;
    public Animator[] _animator;

    //Variable Can Change
    public float speedWalkN;

    //Variable dont need to change
    private bool goForward;
    private bool goLeft;
    private bool goRight;
    private bool goBack;


    void Start()
    {
        //Get Axis
        _rigidbody = GetComponent<Rigidbody>();
        // _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        AnimWalkManager();
        RotateManager();
    }

    public void Walk()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // _rigidbody.AddForce(-Vector3.forward * speedWalkN * Time.deltaTime, ForceMode.Impulse);
            transform.Translate(-Vector3.forward * speedWalkN * Time.deltaTime);
            goForward = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            // _rigidbody.AddForce(Vector3.forward * speedWalkN * Time.deltaTime, ForceMode.Impulse);
            transform.Translate(-Vector3.forward * speedWalkN * Time.deltaTime);
            goBack = true;
        }    
        
        if (Input.GetKey(KeyCode.A))
        {
            // _rigidbody.AddForce(Vector3.forward * speedWalkN * Time.deltaTime, ForceMode.Impulse);
            transform.Translate(-Vector3.forward * speedWalkN * Time.deltaTime);
            goLeft = true;
        }   
        
        if (Input.GetKey(KeyCode.D))
        {
            // _rigidbody.AddForce(Vector3.forward * speedWalkN * Time.deltaTime, ForceMode.Impulse);
            transform.Translate(-Vector3.forward * speedWalkN * Time.deltaTime);
            goRight = true;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            goForward = false;
            goBack = false;
            goLeft = false;
            goRight = false;
        }
    }

    public void AnimWalkManager()
    {
        if (goForward || goBack || goLeft || goRight)
        {
            for (int i = 0; i < _animator.Length; i++)
            {
                _animator[i].SetBool("walkA", true);
            }
        }
        else if (!goForward || !goBack || goLeft || goRight)
        {
            for (int i = 0; i < _animator.Length; i++)
            {
                _animator[i].SetBool("walkA", false);
            }
        }
    }

    public void RotateManager()
    {
        if (goForward)
        {
            if (transform.rotation.y != 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }

        if (goBack)
        {
            if (transform.rotation.y != 180)
            {
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        }

        if (goLeft)
        {
            if (transform.rotation.y != -90)
            {
                transform.rotation = Quaternion.Euler(0,-90,0);
            }
        }   
        
        if (goRight)
        {
            if (transform.rotation.y != 90)
            {
                transform.rotation = Quaternion.Euler(0,90,0);
            }
        }
        
        
    }
}