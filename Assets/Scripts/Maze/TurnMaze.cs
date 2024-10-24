using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaze : MonoBehaviour
{
    ////public float rotationSpeed = 5f; //Variable to store the rotation speed
    //public float rotationSpeed = 5f; //Variable to store the rotation speed
    //private float plusKeyHeld = 0;
    //private float minusKeyHeld = 0;
    public float rotationSpeed = 5f; // Variable to store the rotation speed
    private float rotationDirection = 0f; // -1 for left, 1 for right, 0 for no rotation
    public AudioClip mazeTurn;
    public AudioSource turnSource;

    // Start is called before the first frame update
    void Start()
    {
        if(turnSource == null)
        {
            turnSource = GetComponent<AudioSource>();
        }           
    }

    // Update is called once per frame
    void Update()
    {
        //Booleans that determine if the player has hit the E or Q keys
        //bool turnRight = Input.GetKey(KeyCode.Equals) && Input.GetKeyDown(KeyCode.LeftShift);
        //bool turnLeft = Input.GetKey(KeyCode.Minus);
        //bool plusKeyPressed = false;
        //bool minusKeyPressed = false;
        // Check if the Equals (+) key was pressed to rotate right
        if (Input.GetKey(KeyCode.Equals))
        {
            rotationDirection = 1f; // Set the direction to rotate right
        }

        // Check if the Minus (-) key was pressed to rotate left
        if (Input.GetKey(KeyCode.Minus))
        {
            rotationDirection = -1f; // Set the direction to rotate left
        }

        // Rotate the maze based on the current rotation direction
        if (rotationDirection != 0f)
        {
            // Rotate along the Z axis
            transform.Rotate(0, 0, rotationSpeed * rotationDirection * Time.deltaTime);
            
            //Play audio clip if not already playing 
            if(!turnSource.isPlaying)
            {
                turnSource.clip = mazeTurn; //Setting the audio clip
                turnSource.Play(); //Play audio clip
            }
        }

        //Booleans that determine if the player has hit the E or Q keys
        //bool turnRight = Input.GetKey(KeyCode.Equals);
        //bool turnLeft = Input.GetKey(KeyCode.Minus);

        ////if (turnRight)
        ////{
        ////    plusKeyHeld = !plusKeyHeld; // Toggle the state
        ////    transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        ////}

        //if (turnRight)
        //{
        //    plusKeyHeld = 1; // Toggle the state
        //    if (plusKeyHeld == 1)
        //    {
        //        Debug.Log("Plus key is being held down.");
        //        // Perform actions as if "+" is held down

        //        //Rotate the maze clock wise by the rotation speed by time along the Z axis 
        //        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //    }
        //}

        //if (turnLeft)
        //{
        //    minusKeyHeld = -1; // Toggle the state
        //    if (minusKeyHeld == -1)
        //    {
        //        Debug.Log("Minus key is being held down.");
        //        // Perform actions as if "-" is held down


        //        //Rotate the maze counter-clock wise by the rotation speed by time along the Z axis 
        //        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        //    }
        //}






       

    }
}

