using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

    public float Speed = 3.5f;

    GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		transform.LookAt(player.transform.position);
		
        if (distanceToPlayer <= 30.0f)
        {
            audio.enabled = true;
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        else
        {
            audio.enabled = false;
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
		{
			Speed *= 0.7f;
		}
	}
}
