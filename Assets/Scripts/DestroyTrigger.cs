using UnityEngine;
using System.Collections;

public class DestroyTrigger : MonoBehaviour {

	IEnumerator DestroyParent()
	{
		yield return new WaitForSeconds(10);
		Destroy(transform.parent.gameObject);
	}

    public void DestroySegment()
    {
        StartCoroutine("DestroyParent");
    }
}
