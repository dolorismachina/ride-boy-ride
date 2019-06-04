using UnityEngine;
using System.Collections;

public class RoadSegment : MonoBehaviour {
    GameObject previousSegment;

    public GameObject PreviousSegment
    {
        get { return previousSegment; }
        set { previousSegment = value; }
    }
}
