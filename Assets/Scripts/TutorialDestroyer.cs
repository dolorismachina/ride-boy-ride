using UnityEngine;
using System.Collections;

public class TutorialDestroyer : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
