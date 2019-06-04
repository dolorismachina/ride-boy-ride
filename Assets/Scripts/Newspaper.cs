using UnityEngine;
using System.Collections;

public class Newspaper : MonoBehaviour 
{
	void Start () {
        Physics.IgnoreCollision(collider, GameObject.Find("Player").collider);

		rigidbody.velocity = transform.forward * 25f;
	}

    void Update()
    {
        transform.Rotate(transform.right, 720 * Time.deltaTime);
    }
}
