using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    bool completed;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");

	    if (PlayerPrefs.HasKey("TutorialCompleted"))
        {
            if (PlayerPrefs.GetInt("TutorialCompleted") == 1)
            {
                player.transform.position = new Vector3(0f, 0.18f, 0f);

                Destroy(gameObject);
            }
              
        }
	}

    void Update()
    {
        if (player.transform.position.z >= 0)
        {
            PlayerPrefs.SetInt("TutorialCompleted", 1);
        }
    }
}
