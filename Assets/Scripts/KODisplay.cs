using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KODisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Image gameOverImage;
    public float displayDuration = 5f; // Adjust this duration as needed

    private void Start()
    {
        // Initially, hide the game over image
        gameOverImage.gameObject.SetActive(false);
    }

    public void ShowGameOverImage()
    {
        // Show the game over image
        gameOverImage.gameObject.SetActive(true);

        // Start a coroutine to hide the image after a delay
        StartCoroutine(HideGameOverImage());
    }

    private IEnumerator HideGameOverImage()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the game over image
        gameOverImage.gameObject.SetActive(false);
    }
}
