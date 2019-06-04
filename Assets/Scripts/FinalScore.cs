using UnityEngine;
using System.Collections;

public class FinalScore : MonoBehaviour {

    public AudioClip NewRecord;
    public AudioClip GameOver;

	// Use this for initialization
	void Start () {
        float score = PlayerPrefs.GetFloat("Score");
        float hiScore = PlayerPrefs.GetFloat("HiScore");

        score = 20;
        if (score > hiScore)
        {
            GameObject.Find("New Record").guiText.enabled = true;
            GameObject.Find("New Record").GetComponent<Blink>().on = true;

            audio.clip = NewRecord;
        }
        else
        {
            GameObject.Find("New Record").guiText.text = "Game Over!";
            GameObject.Find("New Record").guiText.enabled = true;
            GameObject.Find("New Record").GetComponent<Blink>().on = true;
            audio.clip = GameOver;
        }

        string scoreMessage = "You scored: " + Mathf.FloorToInt(score).ToString() + " points\n\n";
        scoreMessage += PlayerPrefs.GetInt("NewspapersToDoormat").ToString() + " newspapers on a doormat\n\n";
        scoreMessage += PlayerPrefs.GetInt("NewspapersToDoor").ToString() + " newspapers to door\n\n";
        scoreMessage += PlayerPrefs.GetInt("NewspapersToMailbox").ToString() + " newspapers in the mailbox\n\n";
        //scoreMessage += "You successfuly delivered " + PlayerPrefs.GetInt("NewspapersToDoormat") + PlayerPrefs.GetInt("NewspapersToDoor") + PlayerPrefs.GetInt("NewspapersToMailbox") + " newspapers!";
        guiText.text = scoreMessage;

        audio.Play();
	}
}
