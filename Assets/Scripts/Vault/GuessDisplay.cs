using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GuessDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;

    public SafeUnlocker safe;
    public string letter; //{ get; private set; }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        letter = "?";
        text.text = letter;
    }

    public void SetLetter()
    {
        Debug.Log(letter);
        text.text = letter;
    }

    private void Update()
    {
        if (safe.GetCurrentGuess() != null)
        {
            letter = safe.GetCurrentGuess();
            SetLetter();

        }

    }
}
