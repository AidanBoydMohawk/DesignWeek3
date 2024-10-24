using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPrompt : MonoBehaviour
{
    public Board board;
    public TextMeshProUGUI answerText;
    
    // Start is called before the first frame update
    void Start()
    {
        answerText = GetComponent<TextMeshProUGUI>();
        SetRandomWord();
    }

   void SetRandomWord()
    {
        string randomWord = board.SetRandomWord();
        answerText.text = randomWord;
    }
}
