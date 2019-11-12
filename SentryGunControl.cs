using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryGunControl : MonoBehaviour {
    public GameObject PlayerObject;
    public float fireRate;
    public float timer;
    public GameObject BulletType;
    // Use this for initialization
    void OnEnable () {
        timer = Time.fixedTime + (fireRate * 1.1f);//Slightly longer delay for first bullet
    }
	
	// Update is called once per frame
	void Update () {
        /*
        float x = transform.position.x - PlayerObject.transform.position.x;
        float y = transform.position.y - PlayerObject.transform.position.y;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        */
        if (Time.fixedTime > timer)
        {
            timer = Time.fixedTime + fireRate;
            Fire();
        }
    }
    void Fire()
    {
        GameObject bullet;
        Vector3 bulletLocation = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 delta = bulletLocation - transform.parent.position;
        bulletLocation += delta.normalized * .5f;
        bullet = (Instantiate(BulletType, bulletLocation, Quaternion.identity)) as GameObject;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * 10;
        Destroy(bullet, 1.0f);
    }
    public void setTimer(float time)
    {
        timer = Time.fixedTime + time;
    }
}
