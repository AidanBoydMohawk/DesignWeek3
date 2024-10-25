using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorSwitch : MonoBehaviour
{
    public PlayableDirector timelineDirector; //Playable director component to control timeline
    public float playbackSpeed = 1f; //Speed of timeline playback

    private bool isReverse = false; //Keep track of when the reverse playback

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If space key is hit
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //Play timeline
            timelineDirector.Play();
            isReverse = false;
        }

        //If the R key is hit 
        if (Input.GetKey(KeyCode.A))
        {
            //Set the isReverse bool to true
            isReverse = true;
        }

        if(isReverse)
        {
            timelineDirector.time -= playbackSpeed * Time.deltaTime;

            if(timelineDirector.time <= 0)
            {
                timelineDirector.time = 0;
                isReverse = false;
            }

            timelineDirector.Evaluate();
        }

    }
}
