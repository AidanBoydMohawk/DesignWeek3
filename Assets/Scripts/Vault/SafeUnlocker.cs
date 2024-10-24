using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class SafeUnlocker : MonoBehaviour
{
    //all letters for combination 
    private char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    private float minusOrPlusCheck = 0f;

    int index = 0;

    public float rotationSpeed = 5f;

    //array to store answer 
    public char[] answer = new char[3];

    private void Awake()
    {
       GenerateAnwser();
    }

    private void Update()
    {
        bool confirm;

        bool left = Input.GetKeyDown(KeyCode.Minus);
        bool right = Input.GetKeyDown(KeyCode.Equals);

        if (right)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

            minusOrPlusCheck = 1f;
        }

        if (left)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

            minusOrPlusCheck = -1f;
        }

        if(Input.GetKeyDown("1"))
        {
            confirm = true;
        }
        else
        {
            confirm = false;
        }

        if (letters[index] == answer[index] && confirm)
        {
            answer[index]++;
        }

        if (index == 3)
        {
            Debug.Log("yay");
        }

    }

    public void GenerateAnwser()
    {
        for(int i = 0; i < 3; i++ )
        {
            int stuff = UnityEngine.Random.Range(0, 25);

            answer[i] = letters[stuff];
        }

    }
   
}
