﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is to set up basic movement for the Wizard

    // Necessary
    public Vector3 wizardPosition;            
    public Vector3 direction;                 
    public Vector3 velocity;

    //removed, legacy items, may add later to accelerate the player briefly between zero and max speed

    //Vector3 acceleration;                
    //Vector3 decceleration;
    //float accelRate;                     

    Vector3 worldMousePostition;
    public float angleOfRotation;      
    [SerializeField]
    float maxSpeed = 1f;

    Vector3 vectorZero = new Vector3(0, 0, 0);
    Vector3 W = new Vector3(0f, 1f,0);
    Vector3 A = new Vector3(-1f, 0f);
    Vector3 S = new Vector3(0f, -1f);
    Vector3 D = new Vector3(1f, 0f);

    // Use this for initialization
    void Start()
    {
        wizardPosition = new Vector3(0, 0, -1);     
        direction = new Vector3(1, 0, 0);           
        velocity = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //RotateWizard();

        moveWizard();

        SetTransform();
    }

    /// <summary>
    /// Changes / Sets the transform component
    /// </summary>
    public void SetTransform()
    {
        // Rotate Wizard sprite
        //transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        // Set the transform position
        transform.position = wizardPosition;
    }

    /// <summary>
    /// 
    /// </summary>
    public void moveWizard()
    {
        //zero the velocity
        velocity = vectorZero;


        if (Input.GetKey(KeyCode.W))
        {
            //add the up direction
            velocity += W;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //add the left direciton
            velocity += A;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //add the down direction
            velocity += S;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //add the left direciton
            velocity += D;
        }


        // Limit velocity so it doesn't become too large
        velocity = velocity.normalized *maxSpeed *Time.deltaTime;
        wizardPosition = wizardPosition +velocity;
    }

    public void RotateWizard()
    {
        // Player can control direction
        // Left arrow key = rotate left by 2 degrees
        // Right arrow key = rotate right by 2 degrees
        if (Input.GetKey(KeyCode.A))
        {
            angleOfRotation += 2;
            direction = Quaternion.Euler(0, 0, 2) * direction;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            angleOfRotation -= 2;
            direction = Quaternion.Euler(0, 0, -2) * direction;
        }
    }
}
