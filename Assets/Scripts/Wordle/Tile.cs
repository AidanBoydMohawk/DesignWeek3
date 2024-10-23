using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [System.Serializable]

    //state of the tile 
    public class State
    {
        public Color fillColor;
        public Color outlineColor;
    }

    //public get private set for state and characters
    public State state { get; private set; }
    public char letter { get; private set; }

    //tile components
    private Image fill;
    private Outline outline;
    private TextMeshProUGUI text;

    //when the script first runs
    private void Awake()
    {
        fill = GetComponent<Image>();
        outline = GetComponent<Outline>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    //changing letter within tile to what is typed 
    public void SetLetter(char letter)
    {
        this.letter = letter;
        text.text = letter.ToString();
    }

    //setting state of tile to show progress
    //changing color of tile and outline effect 
    public void SetState(State state)
    {
        this.state = state;
        fill.color = state.fillColor;
        outline.effectColor = state.outlineColor;
    }

}