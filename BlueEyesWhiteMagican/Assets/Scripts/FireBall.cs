using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is meant to move the fireball

    //fields
    WizardMovement Wizard;
    float speed = 0.05f;
    Vector3 direction;
    Vector3 velocity;
    float maxSpeed;
    Vector3 fireballPosition;
    float angle;
    Camera main;
    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to the wizard
        Wizard = GameObject.Find("Wizard").GetComponent<WizardMovement>();

        //set the direction of the bullet
        direction = Wizard.direction;
        velocity = Wizard.velocity;
        fireballPosition = Wizard.wizardPosition;
        maxSpeed = 0.1f;
        angle = Wizard.angleOfRotation;
        main = Camera.main;

        height = 2f * main.orthographicSize;
        width = height * main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        //call the method to move the bullet
        movement();

        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = fireballPosition;

        //destory the fireball if it is off screen 
        OffScreen();
    }

    //method to make the fireball move
    void movement()
    {
        velocity = direction * speed;

        // Limit velocity so it doesn't become too large
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Add velocity to vehicle's position
        fireballPosition += velocity;
    }

    //method to check if the fireball is off screen
    void OffScreen()
    {
        //get the min and max of the camera height and width
        float minX = (width / 2) * -1;
        float maxX = (width / 2);
        float minY = (height / 2) * -1;
        float maxY = (height / 2);

        //check the conditions to sees if off screen
        if(transform.position.x < minX ||
            transform.position.x > maxX ||
            transform.position.y < minY ||
            transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }
}
