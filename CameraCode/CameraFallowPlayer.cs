using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public Vector3 offset2;
    public Vector3 offset3;
    public Vector3 offset4;
    public Vector3 offset5;

    public int camInt;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    

    void LateUpdate()
    {
        
        camInt = PlayerPrefs.GetInt("Cam");
        if (PlayerPrefs.GetInt("Cam") == 0)
        {
            transform.position = player.transform.position + offset;
            transform.rotation = Quaternion.Euler(90, 180, transform.rotation.z);
        }
        else if (PlayerPrefs.GetInt("Cam") == 1)
        {
            transform.position = player.transform.position + offset2;
            transform.rotation = Quaternion.Euler(90, 180, transform.rotation.z);
        }     
        else if (PlayerPrefs.GetInt("Cam") == 2)
        {
            transform.position = player.transform.position + offset3;
            transform.rotation = Quaternion.Euler(90, 180, transform.rotation.z);
        }
        else if (PlayerPrefs.GetInt("Cam") == 3)
        {
            transform.position = player.transform.position + offset4;
            transform.rotation = Quaternion.Euler(0,180,0);
        }    
        else if (PlayerPrefs.GetInt("Cam") == 4)
        {
            transform.position = player.transform.position + offset5;
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    public void ChangeCamera()
    {
        print("i work");
        if (PlayerPrefs.GetInt("Cam") == 0) 
        {
            PlayerPrefs.SetInt("Cam", 1);
        }
        else if(PlayerPrefs.GetInt("Cam") == 1)
        {
            PlayerPrefs.SetInt("Cam", 2);
        }
        else if(PlayerPrefs.GetInt("Cam") == 2)
        {
            PlayerPrefs.SetInt("Cam", 3);
        }   
        else if(PlayerPrefs.GetInt("Cam") == 3)
        {
            PlayerPrefs.SetInt("Cam", 4);
        }  
        else if(PlayerPrefs.GetInt("Cam") == 4)
        {
            PlayerPrefs.SetInt("Cam", 0);
        }     

    }
    
}