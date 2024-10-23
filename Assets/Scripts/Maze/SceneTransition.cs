using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void WordleLevel()
    {
        SceneManager.LoadScene("Wordle");
    }

    public void VaultLevel()
    {
        SceneManager.LoadScene("Vault");
    }

    public void EncryptionLevel()
    {
        SceneManager.LoadScene("Decryption");
    }

    public void MazeLevel()
    {
        SceneManager.LoadScene("Maze");
    } 

    public void MenuScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
