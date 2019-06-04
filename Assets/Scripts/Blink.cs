using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

    float timeSinceStateChange;
    public bool on;

	// Update is called once per frame
	void Update () {
        timeSinceStateChange += Time.deltaTime;
        
        if (on && timeSinceStateChange > 0.5f)
        {
            guiText.enabled = !guiText.enabled;
            timeSinceStateChange = 0f;
        }
	}
}
