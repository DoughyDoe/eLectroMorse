using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryEnemy : MonoBehaviour {
    public GameObject PlayerObject;
    public GameObject BulletType;
	
	// Update is called once per frame
	void Update () {
        if (PlayerObject == null) return;
        float x = transform.position.x - PlayerObject.transform.position.x;
        float y = transform.position.y - PlayerObject.transform.position.y;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    
}