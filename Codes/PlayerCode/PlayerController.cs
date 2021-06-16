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
    public float speedJump;

    //Variable dont need to change
    private float moveX;
    private float moveY;
    private Vector3 input;
    private Quaternion targetRotation;


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
        else if (moveX == 0 || moveY == 0)
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

    public void Jump()
    {
        _rigidbody.AddForce(0,speedJump * Time.deltaTime, 0);
    }
}