using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    public int HP;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        string Coltag = col.gameObject.tag;
        if (Coltag == "Bolt")
        {
            Debug.Log("Hit!");
            Debug.Log(HP);
            HP -= 1;
            Debug.Log(HP);
            if (HP <= 0)
            {

                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
        
    }
}
