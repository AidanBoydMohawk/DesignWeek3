using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SafeUnlocker : MonoBehaviour
{
    //all letters for combination 
    [SerializeField]
    public char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    int index = 0;

    int currentLetter = 0;

    public float rotationSpeed = 5f;

    char guess;

    //array to store answer 
    public char[] answer = new char[3];

    bool confirm;

    bool right;

    bool left;

    bool correct;

    bool victory;

    private void Awake()
    {
        GenerateAnwser();
    }

    private void Update()
    {
        CheckInputs();

        GetCurrentGuess();

        if (index == 3)
        {

            victory = true;
        }
    }

    public void GenerateAnwser()
    {
        for (int i = 0; i < 3; i++)
        {
            int stuff = UnityEngine.Random.Range(0, 25);

            answer[i] = letters[stuff];
        }

    }

    public void CheckInputs()
    {


        if (Input.GetKeyDown("1"))
        {
            confirm = true;
        }
        else if (Input.GetKeyUp("1"))
        {
            confirm = false;
        }

        if (Input.GetKeyDown("="))
        {
            right = true;
            transform.Rotate(new Vector3(0, 0, -14.4f)); // this isnt a random set of numbers it is 360 divided by 25

            currentLetter++;
            if (currentLetter > 25)
            {
                currentLetter = 0;
            }

            Debug.Log(letters[currentLetter]);
        }
        else if (Input.GetKeyUp("="))
        {
            right = false;
        }

        if (Input.GetKeyDown("-"))
        {
            left = true;
            transform.Rotate(new Vector3(0, 0, 14.4f));

            currentLetter--;
            if (currentLetter < 0)
            {
                currentLetter = 25;
            }

            Debug.Log(letters[currentLetter]);
        }
        else if (Input.GetKeyUp("-"))
        {
            left = false;
        }

    }



    public string GetCurrentGuess()
    {
        if (letters[currentLetter] == answer[index] && confirm)
        {
            correct = true;

            if (correct)
            {
                index++;
                Debug.Log("yay");
                confirm = false;
                correct = false;
                return letters[currentLetter].ToString();

            }

        }


        return null;

    }
}
