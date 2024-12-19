using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb2d;
    float torque = 1f;

    SurfaceEffector2D surfaceEffector2D;

    bool canMove = true;
    
    void Start()
    {   
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectsByType<SurfaceEffector2D>((FindObjectsSortMode)FindObjectsInactive.Include)[0];
    }

    // Update is called once per frame
    void Update()
    {   
        if (canMove){
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls(){
        canMove = false;
    }

    void RespondToBoost()
    {
        // if we push up, then speed up
        if(Input.GetKey(KeyCode.W)){
            surfaceEffector2D.speed = 30;
        }else {
            surfaceEffector2D.speed = 15;
        }
        //otherwise stay
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torque);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torque);
        }
    }
}
