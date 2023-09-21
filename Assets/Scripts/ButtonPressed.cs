using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    public new AudioSource audio;
    void Start()
    {
        button = GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        Debug.Log("Play");
        audio.Play();
    }
}
