using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBolt : MonoBehaviour {

    public GameObject effect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bolt")
        {
            GameObject bulletDespawn = (Instantiate(effect, transform.position, Quaternion.identity) as GameObject);
            Destroy(collision.gameObject);
        }
    }
}
