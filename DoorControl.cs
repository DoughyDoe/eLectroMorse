using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {
    public int EnemyThreshold; //Closed if more than this number of enemies exist in scene
	// Use this for initialization
	void Start () {
        if (EnemyThreshold < GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (EnemyThreshold < GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
