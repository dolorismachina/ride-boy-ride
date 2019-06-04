using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private void Start()
    {
        float hiScore = PlayerPrefs.GetFloat("HiScore");
        GameObject.Find("Hi Score").guiText.text = "Hi score: " + Mathf.FloorToInt(hiScore).ToString();
    }

    public void OnPause()
    {
        foreach (Transform t in transform.Find("Audio"))
        {
            t.audio.Pause();
        }
    }

    public void OnResume()
    {
        foreach (Transform t in transform.Find("Audio"))
        {
            t.audio.Play();
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
