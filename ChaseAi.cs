using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ChaseAi : MonoBehaviour {


    public GameObject greenBulletPrefab;
    public Transform target;
    public float speed;
    public float period = 0.2f;
    public float offset = .5f;
    public Vector3 lastFirePosition;
    private float timer;
    public float delay;


    private float nextActionTime = 0.0f;
    

    // Use this for initialization
    void OnEnable () {
        timer = Time.fixedTime + delay;
        lastFirePosition = transform.position;
}
	
	// Update is called once per frame
	void Update () {
        if (Time.fixedTime > timer && target != null)
        {
            Vector3 currentPosition = transform.position;
            if (Time.time > nextActionTime && Vector3.Distance(lastFirePosition, currentPosition) > 0.5f)
            {
                nextActionTime = Time.time + period;
                lastFirePosition = currentPosition;
                //RandomFire();
                Fire();
            }


            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }


    void Fire()
    {
        GameObject enemyBullet;
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        enemyBullet = (Instantiate(greenBulletPrefab, position, Quaternion.identity)) as GameObject;
        Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
        Destroy(enemyBullet, 3.5f);
    }
    void Explode()
    {

    }
}
