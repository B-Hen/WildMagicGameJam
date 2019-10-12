using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is to set up basic movement for the Wizard

    // Necessary
    float accelRate;                     
    public Vector3 wizardPosition;            
    public Vector3 direction;                 
    public Vector3 velocity;                 
    Vector3 acceleration;                
    Vector3 decceleration;
    public float angleOfRotation;             
    float maxSpeed;                      

    // Use this for initialization
    void Start()
    {
        wizardPosition = new Vector3(0, 0, 0);     
        direction = new Vector3(1, 0, 0);           
        velocity = new Vector3(0, 0, 0);
        maxSpeed = 0.1f;
        accelRate = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateWizard();

        moveWizard();

        SetTransform();
    }

    /// <summary>
    /// Changes / Sets the transform component
    /// </summary>
    public void SetTransform()
    {
        // Rotate Wizard sprite
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        // Set the transform position
        transform.position = wizardPosition;
    }

    /// <summary>
    /// 
    /// </summary>
    public void moveWizard()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            // Accelerate
            // Small vector that's added to velocity every frame
            acceleration = accelRate * direction;

            //add the velocity to the Wizard
            velocity += acceleration;
        }
        else if (Input.GetKey(KeyCode.W) == false)
        {
            decceleration = velocity * 0.09f;

            velocity -= decceleration;
        }
        // Limit velocity so it doesn't become too large
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        wizardPosition += velocity;
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
