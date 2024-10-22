using UnityEngine;

public class Row : MonoBehaviour
{
    //public getting and private setting tile values
    public Tile[] tiles { get; private set; }

    //word used inside of row 
    public string word
    {
        //get the word 
        get
        {
            string word = "";

            for (int i = 0; i < tiles.Length; i++)
            {
                word += tiles[i].letter;
            }

            return word;
        }
    }

    //getting tiles children when run
    private void Awake()
    {
        tiles = GetComponentsInChildren<Tile>();
    }

}