using UnityEngine;
using System.Collections;

public class OldMan : MonoBehaviour 
{
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            transform.Rotate(Vector3.up, 180.0f);
        }
    }

	// Update is called once per frame
	void Update () {
		transform.Translate((Vector3.forward) * Time.deltaTime * 1.5f);
	}
}