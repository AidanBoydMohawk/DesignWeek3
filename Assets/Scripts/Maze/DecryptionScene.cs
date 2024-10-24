using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecryptionScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with this object
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Decryption"); //Transition to Wordle Puzzle
        }
    }
}
