using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IPausable 
{
    public float RotationSpeed = 200.0f;
    public float Speed = 6.0f;
    public GameObject Newspaper; 
    
    bool paused = false;
    Vector3 checkpointPosition;
    Quaternion checkpointRotation;
    Score score;
    float timeSinceLastthrow;

	public void OnPause()
	{
        transform.Find("bicycle").audio.Pause();
	}

    public void OnResume()
    {
        transform.Find("bicycle").audio.Play();
    }

	void Start()
	{
		score = GameObject.Find("Score").GetComponent<Score>();
	}

	void Update () 
	{
        // Place the player back on the road if he falls off the map.
        if (FellOffTheMap())
        {
            Respawn();
        }

        TurnTheBike();


        if (Input.GetKey(KeyCode.S))
        {
            if (Speed > 3)
            {
                Speed -= 3 * Time.deltaTime;
            }
        }
        else
        {
            Accelerate();
        }

        Vector3 nextPosition = Vector3.forward * Time.deltaTime * Speed;
		score.Points += nextPosition.z;

        
        transform.Translate(nextPosition);
        timeSinceLastthrow += Time.deltaTime;

		if (Input.GetKeyUp(KeyCode.P))
		{
            PauseGame();
		}

        if (Input.GetMouseButtonDown(0))
        {
            ThrowNewspaper();
        }
	}

    private void Accelerate()
    {
        if (Speed < 6.0)
        {
            Speed += 5f * Time.deltaTime;
        }
        if (Speed > 6.0)
        {
            Speed = 6.0f;
        }
    }

    private void TurnTheBike()
    {
        transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * 90f));
    }

    private bool FellOffTheMap()
    {
        return transform.position.y < -5.0f;
    }

    // Puts the player in the position and rotation of last registered checkpoint.
    private void Respawn()
    {
        transform.position = checkpointPosition;
        transform.rotation = checkpointRotation;
    }

    private void ThrowNewspaper()
    {
        if (Time.timeScale > 0) // if the game is not paused.
        {
            if (MousePositionToWorldPoint(Input.mousePosition).collider) // If player clicked on a visible game object.
            {
                if (timeSinceLastthrow >= 1.0f) // If enough time has passed since last throw.
                {
                    Vector3 target = MousePositionToWorldPoint(Input.mousePosition).point;

                    // Get a point in the world directly above the player.
                    Vector3 spawnLocation = GetSpawnLocation(target);

                    GameObject newspaper = Instantiate(Newspaper, spawnLocation, Quaternion.identity) as GameObject;
                    newspaper.transform.LookAt(target);

                    timeSinceLastthrow = 0.0f;
                }
            }
        }
    }

    private Vector3 GetSpawnLocation(Vector3 target)
    {
        Vector3 spawnLocation = transform.position + new Vector3(
            (collider as BoxCollider).center.x,
            (collider as BoxCollider).center.y + (collider as BoxCollider).size.y * 0.5f,
            (collider as BoxCollider).center.z);

        // Modify the spawnLocation so that it points to a point between the player and newspaper's target.
        spawnLocation = spawnLocation + Vector3.Normalize(target - spawnLocation) * 0.5f;

        return spawnLocation;
    }

    private void PauseGame()
    {
        paused = !paused;

        GameObject[] objects = FindObjectsOfType<GameObject>();
        if (paused)
        {
            Time.timeScale = 0;
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnPause");
            }
        }
        else
        {
            Time.timeScale = 1;

            foreach (GameObject go in objects)
            {
                go.SendMessage("OnResume");
            }
        }
    }

    // Finds the nearest predefined angle depending on current rotation.
    // Returns Quaternion rotation.
    private Quaternion FindTargetRotation()
    {
        float targetAngleY;
        if (transform.localEulerAngles.y >= 45 && transform.localEulerAngles.y < 135)
        {
            targetAngleY = 90f;
        }
        else if (transform.localEulerAngles.y >= 135 && transform.localEulerAngles.y < 225)
        {
            targetAngleY = 180f;
        }
        else if (transform.localEulerAngles.y >= 225 && transform.localEulerAngles.y < 315)
        {
            targetAngleY = 270f;
        }
        else
        {
            targetAngleY = 0f;
        }

        return Quaternion.Euler(0, targetAngleY, 0);
    }

    /// <summary>
    /// </summary>
    /// <param name="screenPoint">Mouse position.</param>
    /// <returns>GameObject placed under the mouse pointer.</returns>
    GameObject GetSelectedObject(Vector3 screenPoint)
    {
        return MousePositionToWorldPoint(screenPoint).collider.gameObject;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="screenPoint">Mouse position.</param>
    /// <returns>Posiion of the mouse in the world coordinates.</returns>
    RaycastHit MousePositionToWorldPoint(Vector3 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        
        return hit;
    }

    // Rotates the object back towards a predefined angle.
    // speed is speed of rotation expressed as degrees per second.
    private void RotateBack(float speed)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, FindTargetRotation(), speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Checkpoint")
        {
            checkpointPosition = col.transform.position;
            checkpointRotation = col.transform.rotation;
        }
    }
}
