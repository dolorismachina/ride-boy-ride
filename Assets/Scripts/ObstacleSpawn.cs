using UnityEngine;
using System.Collections;
using System;

public class ObstacleSpawn : MonoBehaviour {

	public GameObject[] Obstacles;
	int spawnChance = 5;
    int spawnChanceDogOnPavement = 4;
    int spawnChanceDogOnRoad = 2;

	void Start () 
    {
        TimeSpan timeRemaining = GameObject.Find("Timer").GetComponent<Timer>().TimeRemaining;
        if (timeRemaining.Minutes < 3)
        {
            spawnChance += 1;
        }
        else if (timeRemaining.Minutes < 2)
        {
            spawnChance += 2;
        }
        else if (timeRemaining.Minutes < 1)
        {
            spawnChance += 3;
        }

        int rnd = UnityEngine.Random.Range(0, 10);
		
        if (rnd < spawnChance) 
        {
            int rndEnemy = UnityEngine.Random.Range(0, 3);

            if (IsPavement())
            {
                if (Obstacles[rndEnemy].name == "dog")
                {
                    if (UnityEngine.Random.Range(0, 10) < spawnChanceDogOnPavement)
                    {
                        SpawnObstacle(rndEnemy);
                    }
                }
                else
                {
                    SpawnObstacle(rndEnemy);
                }
            }
			else  if (Obstacles[rndEnemy].name != "chr_old")
            {
                if (Obstacles[rndEnemy].name == "dog")
                {
                    if (UnityEngine.Random.Range(0, 10) < spawnChanceDogOnRoad)
                    {
                        SpawnObstacle(rndEnemy);
                    }
                }
                else
                {
                    SpawnObstacle(rndEnemy);
                }
            }
		}
	}

    private void SpawnObstacle(int rndEnemy)
    {
        GameObject go = Instantiate(Obstacles[rndEnemy], transform.position, transform.rotation) as GameObject;
        go.transform.parent = this.transform;
        go.transform.position = this.transform.position;
    }

    private bool IsPavement()
    {
        return transform.parent.name != "Obstacles Middle";
    }
}
