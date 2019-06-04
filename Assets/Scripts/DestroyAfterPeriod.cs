using UnityEngine;
using System.Collections;

public class DestroyAfterPeriod : MonoBehaviour {
	public float Seconds = 2;

	// Use this for initialization
	void Start () {
		StartCoroutine("HideMessageAfterTimePeriod");
	}
	
	// Update is called once per frame
	void Update () {
	  
	}

    IEnumerator HideMessageAfterTimePeriod()
    {
        yield return new WaitForSeconds(Seconds);
		Destroy(gameObject);
    }
}
