using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public float Points 
    {
	    get;
	    set;
    }

    public int NewspapersToDoor { get; set; }
    public int NewspapersToDoormat { get; set; }
    public int NewspapersToMailbox { get; set; }


	void Update () {
		guiText.text = "Score: " + Mathf.FloorToInt(Points).ToString();

        if (Points < 0)
        {
            Points = 0;
        }
	}
}
