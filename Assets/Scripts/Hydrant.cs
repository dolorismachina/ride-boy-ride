using UnityEngine;
using System.Collections;

public class Hydrant : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            transform.Find("Water Fountain").GetComponent<ParticleEmitter>().emit = true;
        }
    }
}
