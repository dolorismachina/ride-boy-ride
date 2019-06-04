using UnityEngine;

public class Scoreable : MonoBehaviour 
{
	public int Points = 100;
	public GameObject ScoreMessage;

	bool hit;

	Score score;

	void Start()
	{
		score = GameObject.Find ("Score").GetComponent<Score>();
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.tag == "Newspaper" && !hit)
		{
            Destroy(col.gameObject);

            audio.Play();
            hit = true;

            if (transform.parent.name == "house")
            {
                if (!transform.parent.GetComponent<House>().Served)
                {
                    transform.parent.GetComponent<House>().Served = true;

                    if (name == "Door")
                    {
                        score.NewspapersToDoor += 1;
                    }
                    else if (name == "Doormat")
                    {
                        score.NewspapersToDoormat += 1;

                    }
                    else if (name == "mailbox")
                    {
                        score.NewspapersToMailbox += 1;
                    }
                }
                else
                {
                    Points = 0;
                }
            }

			score.Points += Points;

            CreatePopupMessage(col);
		}

	}

    private void CreatePopupMessage(Collider collider)
    {
        Vector3 colliderInViewport = Camera.main.WorldToViewportPoint(collider.transform.position);
        float x = 0; float y = 0;

        // Check if collider is on the screen and make sure the message is created on the screen if not.
        if (colliderInViewport.x > 0 && colliderInViewport.x < 1 &&
            colliderInViewport.y > 0 && colliderInViewport.y < 1)
        {
            x = colliderInViewport.x;
            y = colliderInViewport.y;
        }
        else
        {
            if (colliderInViewport.x < 0 || colliderInViewport.x > 1)
            {
                x = 0.5f;
            }
            if (colliderInViewport.y < 0 || colliderInViewport.y > 1)
            {
                y = 0.5f;
            }
        }

        Vector3 TextLocation = new Vector3(x, y, 0);

        GameObject message = Instantiate(ScoreMessage, TextLocation, Quaternion.identity) as GameObject;
        message.guiText.text = Points.ToString();

        message.transform.FindChild("Particles").position = collider.transform.position;
    }
}
