using UnityEngine;
using System.Collections;

public class SpawnSegment : MonoBehaviour {

	public RoadSegments Segments;
    bool spawned;

	void OnTriggerEnter(Collider col)
	{
		if (!spawned && col.tag == "Player")
        {
            Vector3 newPosition = collider.transform.position + collider.transform.forward * 7.2f * 5.0f;
            GameObject go = Instantiate(GetRandomSegment().gameObject, newPosition, collider.transform.rotation) as GameObject;
            spawned = true;

            go.GetComponent<RoadSegment>().PreviousSegment = transform.parent.gameObject;
        }
	}

	Transform GetRandomSegment()
	{
		int rnd = Mathf.FloorToInt(Random.Range(0, 4));

		if (rnd == 0)
		{
			return Segments.CornerRight;
		}
		else if (rnd == 1)
		{
			return Segments.TJunction;
		}
		else if (rnd == 2)
		{
			return Segments.CrossJunction;
		}
		else if (rnd == 3)
		{
			return Segments.CornerLeft;
		}

        return Segments.Straight;
	}
}

[System.Serializable]
public class RoadSegments
{
	public Transform CornerRight;
	public Transform CornerLeft;
	public Transform Straight;
	public Transform TJunction;
	public Transform CrossJunction;
}