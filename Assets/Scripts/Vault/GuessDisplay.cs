using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GuessDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;

    SafeUnlocker safe;

    
    public char letter { get; private set; }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        GetComponent<SafeUnlocker>();
    }

    public void SetLetter()
    {
        this.letter = letter;
        text.text = letter.ToString();
    }
}
