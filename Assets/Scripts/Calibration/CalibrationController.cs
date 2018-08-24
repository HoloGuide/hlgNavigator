using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using HoloToolkit.Unity.InputModule;

public class CalibrationController : MonoBehaviour, IInputClickHandler
{
    public AudioClip tappedSE;
    public Text Count;

    private int tapCount = 0;
    private AudioSource audioSource;

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
        audioSource = this.GetComponent<AudioSource>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Tapped");
        tapCount++;
        audioSource.PlayOneShot(tappedSE);
        Count.text = tapCount.ToString();

        if (tapCount >= 3)
        {
            SceneManager.LoadScene("EstablishWebSocket");
        }

    }
}
