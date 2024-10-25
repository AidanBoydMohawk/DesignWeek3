using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TMP_InputField playerInputField;
    public string correctPassword = "mySecretPassword"; // Set your password here

    // References for the correct/incorrect password messages
    public GameObject correctMessage;
    public GameObject incorrectMessage;

    // Array of virus panels (fake virus pop-ups)
    public GameObject[] virusPanels;

    // Reference to the 'X' button in each virus panel to close it
    public Button[] closeButtons;

    // Sound effects
    public AudioSource virusPopupSound;
    public AudioSource typingSound;
    public AudioSource correctSound;
    public AudioSource incorrectSound;

    // Interval range for random virus pop-ups (in seconds)
    public float minPopUpInterval = 5f;
    public float maxPopUpInterval = 15f;

    void Start()
    {
        // Ensure both messages are initially hidden
        correctMessage.SetActive(false);
        incorrectMessage.SetActive(false);

        // Set up close buttons for each virus panel
        for (int i = 0; i < closeButtons.Length; i++)
        {
            int index = i; // Capture index for the correct panel
            closeButtons[i].onClick.AddListener(() => CloseVirusPanel(index));
        }

        // Set all virus panels to inactive at the start
        foreach (GameObject image in virusPanels)
        {
            image.SetActive(false);
        }

        // Add listeners for the Input Field
        playerInputField.onEndEdit.AddListener(OnSubmit);
        playerInputField.onValueChanged.AddListener(PlayTypingSound);

        // Start the coroutine for random virus pop-ups
        StartCoroutine(RandomVirusPopUpCoroutine());
    }

    // Method to handle the input submission
    private void OnSubmit(string input)
    {
        // Call CheckPassword when the player finishes editing
        CheckPassword();
    }

    public void CheckPassword()
    {
        string playerInput = playerInputField.text;

        if (playerInput == correctPassword)
        {
            // Show the correct message and load the next scene
            correctMessage.SetActive(true);
            incorrectMessage.SetActive(false); // Hide the incorrect message if visible

            // Play correct password sound
            if (correctSound != null)
            {
                correctSound.Play();
            }

            // Uncomment this to load the next scene
            // SceneManager.LoadScene("NextSceneName"); // Replace with your scene's name
        }
        else
        {
            // Show the incorrect message
            incorrectMessage.SetActive(true);
            correctMessage.SetActive(false); // Hide the correct message if visible
            playerInputField.text = ""; // Clear the input field

            // Play incorrect password sound
            if (incorrectSound != null)
            {
                incorrectSound.Play();
            }
        }
    }

    // Method to play typing sound when the player types
    private void PlayTypingSound(string input)
    {
        if (typingSound != null)
        {
            typingSound.Play();
        }
    }

    // Method to close a virus panel by index
    public void CloseVirusPanel(int index)
    {
        if (index >= 0 && index < virusPanels.Length)
        {
            virusPanels[index].SetActive(false);
        }
    }

    // Method to randomly pop up one of the virus panels
    public void PopUpVirusPanel()
    {
        // Choose a random virus panel to activate
        int randomIndex = Random.Range(0, virusPanels.Length);
        virusPanels[randomIndex].SetActive(true);

        // Play the virus pop-up sound effect
        if (virusPopupSound != null)
        {
            virusPopupSound.Play();
        }
    }

    // Coroutine to trigger random virus pop-ups over time
    private IEnumerator RandomVirusPopUpCoroutine()
    {
        while (true)
        {
            // Wait for a random interval between min and max
            float randomInterval = Random.Range(minPopUpInterval, maxPopUpInterval);
            yield return new WaitForSeconds(randomInterval);

            // Trigger a random virus pop-up
            PopUpVirusPanel();
        }
    }
}
