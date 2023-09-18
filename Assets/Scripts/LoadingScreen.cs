using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public float delayInSeconds = 5f; // Time in seconds to display the loading screen

    private void Start()
    {
        // Start a coroutine to delay the scene transition
        StartCoroutine(ShowLoadingScreen());
    }

    private IEnumerator ShowLoadingScreen()
    {
        // Display the loading screen for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Load the target scene
        SceneManager.LoadSceneAsync(1);
    }
}
