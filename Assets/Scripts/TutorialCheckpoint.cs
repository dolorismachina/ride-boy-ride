using UnityEngine;
using System.Collections;

public class TutorialCheckpoint : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            transform.parent.Find("Message").guiTexture.enabled = true;
        }
    }
}
