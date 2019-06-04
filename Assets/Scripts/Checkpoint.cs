using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

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
            try
            {
                GameObject previousSegment = transform.parent.gameObject.GetComponent<RoadSegment>().PreviousSegment;
                previousSegment.transform.Find("SegmentDestroyer").gameObject.GetComponent<DestroyTrigger>().DestroySegment();
            }
            catch (System.Exception)
            {
                print("Previous segment has already been deleted.");
            }
        }
    }
}
