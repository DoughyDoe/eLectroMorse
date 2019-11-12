using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakenEnemies : MonoBehaviour {
    public GameObject[] Enemies;
	// Use this for initialization
	void Start () {
		foreach(GameObject enemy in Enemies)
        {
            enemy.SetActive(false);
        }
	}
	
	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in Enemies)
            {
                enemy.SetActive(true);
            }
        }
    }
}
