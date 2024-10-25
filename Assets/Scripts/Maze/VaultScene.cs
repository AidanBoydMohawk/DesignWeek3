using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VaultScene : MonoBehaviour
{
    public bool hasCollided = false; //Bool to check if collided 
    public string sceneName = "Vault"; //Scene name to load after collision
    private string objectStateKey; //Key to store the object state

    // Start is called before the first frame update
    void Start()
    {

        objectStateKey = gameObject.name + "_IsActive";

        int state = PlayerPrefs.GetInt(objectStateKey, 1);
        gameObject.SetActive(state == 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {
            gameObject.SetActive(false);
            PlayerPrefs.SetInt(objectStateKey, 0); //Save state as inactive
            PlayerPrefs.Save(); //Ensure the state is saved to disk
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hasCollided = true;

            //Ensure the object persists across scene loads
            DontDestroyOnLoad(gameObject);

            //Load in the wordle scene
            SceneManager.LoadScene(sceneName);
        }
    }


}
