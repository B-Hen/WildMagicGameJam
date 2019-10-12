using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballManager : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is to create and move the fireball when the user presses space

    //fields
    public GameObject fireBall;
    WizardMovement wizard;

    // Start is called before the first frame update
    void Start()
    {
        //get a refernece to the wizard 
        wizard = GameObject.Find("Wizard").GetComponent<WizardMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //check to see that the user has pressed space
        if(Input.GetKey(KeyCode.Space))
        {
            //create a new bullet
            Instantiate(fireBall, wizard.wizardPosition, Quaternion.identity);
        }
    }
}
