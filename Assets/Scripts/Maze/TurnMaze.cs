using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaze : MonoBehaviour
{
    private float rotationSpeed = 100f; //Variable to store the rotation speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Booleans that determine if the player has hit the E or Q keys
        bool turnRight = Input.GetKey(KeyCode.E);
        bool turnLeft = Input.GetKey(KeyCode.Q);

        //If the player is turning right
        if (turnRight)
        {
            //Rotate the maze clock wise by the rotation speed by time along the Z axis 
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        //If the player is turning left
        if (turnLeft)
        {
            //Rotate the maze counter-clock wise by the rotation speed by time along the Z axis 
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime); 
        }
    }
}
