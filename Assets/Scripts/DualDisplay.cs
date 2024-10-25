using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DualDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
