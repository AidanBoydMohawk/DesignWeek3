using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeUnlocker : MonoBehaviour
{
    public GameObject dialObject;

    public int minimumDegrees = 5; //how many degrees you have to turn to register a change
    public int dialNumberAngles = 45; //angle between numbers on dial

    private int[] digitAngles = new int[] { 90, 135, 0 };
    private bool[] digitSet = new bool[3];
    private int[] digitPasses = new int[] {3,3,2};
    private bool[] digitLeftTurn = new bool[] { true, false, true };

    private int passCount; //how many times the angle associated with the current digit has been detected 
    private bool passReset; //true if dial has been rotated 180 degrees past the current digit
    private int currentDigit;

    private bool turningLeft;

    private bool unlocked;

    private int oldAngle;
    private int currentAngle;
    
    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            return;
        }

        //reset if turning in wrong direction
        if (digitLeftTurn[currentDigit] != turningLeft && oldAngle != currentAngle)
        {
            passCount = 0;
            currentDigit = 0;
            for (int i = 0; i < digitSet.Length; i++)
            {
                digitSet[i] = false;
            }

        }

        //Reset Dial rotation back to zero at 360 degrees 
        if(dialObject.transform.localEulerAngles.y > 360 || dialObject.transform.localEulerAngles.y < -360)
        {
            dialObject.transform.localEulerAngles = Vector2.zero;
        }

        //set currentAngle to dial rotation rounded by the sensitivity 
        currentAngle = (int)(Mathf.RoundToInt(dialObject.transform.localEulerAngles.y / minimumDegrees)  * minimumDegrees);

        //reset pass so you only increment passCount once 
        if(!passReset && currentAngle != digitAngles[currentDigit])
        {
            passReset = true;
        }

        //Update on dial number change 
        if(currentAngle % dialNumberAngles == 0) //if the current angle is a multiple of the angle of the numbers on the dial 
        {
            // if the currentAngle has changed to a different dial number and the oldAngle is not zero
            if(currentAngle < oldAngle)
            {
                if (oldAngle != 0 && oldAngle != 360)
                    turningLeft = false; //set turningLeft to false if the current angle has decreassed from the old angle 
                oldAngle = Mathf.RoundToInt(currentAngle / dialNumberAngles) * dialNumberAngles; //updates oldAngle to dial number 
            }
            if(currentAngle > oldAngle)
            {
                if (oldAngle != 0 && oldAngle != 360)
                    turningLeft = true; //set turning left to true if the current angle has increased from the old angle
                oldAngle = Mathf.RoundToInt(currentAngle / dialNumberAngles) * dialNumberAngles; //updates oldAngle to dial number 
            }
        }

        //putting in the safecode 

        if(currentAngle == digitAngles[currentDigit]) //if dial objects rotation angle is equal to the angle of the current digit
        {
            if (passReset)
            {
                passCount++; //increment pass count
                passReset = false;
            }

            if(passCount >= digitPasses[currentDigit]) // if we have turned the dial enough times to move on 
            {
                //increment to the next digit in the safecode
                Debug.Log("Digit" + (currentDigit) + "set");
                digitSet[currentDigit] = true;
                if(currentDigit != digitAngles.Length) //if you're not on the last digit 
                {
                    currentDigit++;
                    turningLeft = digitLeftTurn[currentDigit];
                    passCount = 0;
                }

                // Click Noise 
            }
        }
    }
}
