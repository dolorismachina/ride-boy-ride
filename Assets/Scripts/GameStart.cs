using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour 
{
	void Update () {
	    if (Input.GetKeyUp(KeyCode.Return))
        {
            Application.LoadLevel("Game");
        }
	}
}
