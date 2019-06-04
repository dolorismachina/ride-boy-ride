using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour, IPausable {

	public GameObject PenaltyMessage;
	public int Penalty = 0;

	public void OnPause()
	{
        audio.Pause();
	}
    public void OnResume()
    {
        audio.Play();
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			Destroy (gameObject);

            Vector3 colliderInViewport = Camera.main.WorldToViewportPoint(col.transform.position);

            GameObject message = Instantiate(PenaltyMessage, new Vector3(colliderInViewport.x, colliderInViewport.y, colliderInViewport.z), Quaternion.identity) as GameObject;
			message.guiText.text = "-" + Penalty.ToString();
			GameObject.Find("Score").GetComponent<Score>().Points -= Penalty;

			try {
				audio.Play();
			} 
			catch (System.Exception ex) {
				print (ex.Message);
			}
		}
	}
}
