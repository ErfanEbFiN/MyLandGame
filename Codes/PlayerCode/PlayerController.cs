using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Get Axis
    private Rigidbody _rigidbody;
    public Animator[] _animator;
    public Joystick _joystick;

    //Variable Can Change
    public float speedWalkN;
    public float speedRotate;

    //Variable dont need to change
    private bool goForward;
    private bool goLeft;
    private bool goRight;
    private bool goBack;

    public float moveX;
    public float moveY;

    public Vector3 input;

    Quaternion targetRotation;


    void Start()
    {
        //Get Axis
        _rigidbody = GetComponent<Rigidbody>();
        // _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Walk();
        AnimWalkManager();
        RotateManager();
    }

    public void Walk()
    {
        moveX = _joystick.Horizontal;
        moveY = _joystick.Vertical;

        input = new Vector3(moveX, 0, moveY);
        
        transform.Translate(-moveX * Time.deltaTime * speedWalkN, 0, -moveY * Time.deltaTime * speedWalkN,
            Space.World);
    }

    public void AnimWalkManager()
    {
        if (moveX != 0 || moveY != 0)
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
        transform.rotation = Quaternion.LookRotation(input);
    }
}