using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour {
    public float period = 3f;
    public float speed = 5f;
    public Transform target;
    
    public Vector3[] TeleCoordinates = { new Vector3(2.5f, 2.5f,0f), new Vector3(-2.5f, 2.5f, 0f), new Vector3(-2.5f, -2.5f, 0f), new Vector3(2.5f, -2.5f,0f)  };
    private float nextActionTime = 0.0f;
    private int rand;
    private int min;
    private int max;
    private int count;
    public GameObject bossboltPrefab;

    // Use this for initialization
    void OnEnable() {
        min = 0;
        max = 5;
        nextActionTime = Time.fixedTime + period;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            rand = Random.Range(min,max);
            for (int i = 0; i < 10; i++)
            {
                RandomFire();
            }
        }
        teleport(TeleCoordinates[rand]);
    }
    void move(Vector3 vect)
    {
        //
        float step = speed * Time.deltaTime;
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = -Vector3.MoveTowards(transform.position, vect, step);
    }
    void teleport(Vector3 vector)
    {
        transform.position = vector;
    }
    void RandomFire()
    {
        GameObject enemyBullet;
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f),0,0 );
        Vector3 enemyBulletLocation = new Vector3(transform.position.x, transform.position.y, 0);
        enemyBullet = (Instantiate(bossboltPrefab, transform.position, Quaternion.identity)) as GameObject;
        float step = speed * Time.deltaTime;
        //enemyBullet.transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
        enemyBullet.GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * speed;
        Destroy(enemyBullet, .5f);
        Debug.Log("fucker");
    }
    void BossFire(int random)
    {
        Debug.Log("damn");
        GameObject bullet;
        bullet = (Instantiate(bossboltPrefab, transform.position, Quaternion.identity)) as GameObject;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * random;
        Destroy(bullet, 3);
  
    }
}
