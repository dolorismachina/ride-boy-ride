using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour, IPausable
{
    public int Minutes = 5;
    public int Seconds = 0;
    public TimeSpan TimeRemaining
    {
        get { return timeRemaining; }
        set { timeRemaining = value; }
    }

    TimeSpan timeRemaining;
    DateTime timeEnds;

	void Start () 
    {
        timeEnds = DateTime.Now + new TimeSpan(0, Minutes, Seconds);
	}
	
	// Update is called once per frame
	void Update () 
    {
        guiText.text = String.Format("{0:0}:{1:00}", timeRemaining.Minutes, timeRemaining.Seconds);
        if (Time.timeScale > 0)
        {
            timeRemaining = timeEnds - DateTime.Now;
        }

        if (timeRemaining.Minutes == 0 && timeRemaining.Seconds <= 0)
        {
            float finalScore = GameObject.Find("Score").GetComponent<Score>().Points;
            PlayerPrefs.SetFloat("Score", finalScore) ;
            PlayerPrefs.SetInt("NewspapersToDoor", GameObject.Find("Score").GetComponent<Score>().NewspapersToDoor);
            PlayerPrefs.SetInt("NewspapersToDoormat", GameObject.Find("Score").GetComponent<Score>().NewspapersToDoormat);
            PlayerPrefs.SetInt("NewspapersToMailbox", GameObject.Find("Score").GetComponent<Score>().NewspapersToMailbox);
            
            if (finalScore > PlayerPrefs.GetFloat("HiScore"))
            {
                PlayerPrefs.SetFloat("HiScore", Mathf.FloorToInt(finalScore));
            }

            PlayerPrefs.Save();

            Application.LoadLevel("GameOver");
        }
	}
    
    private DateTime timePaused;
    public void OnPause()
    {
        timePaused = DateTime.Now;
    }

    public void OnResume()
    {
        timeEnds += DateTime.Now - timePaused;
    }
}
