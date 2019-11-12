using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyEnemyAI : MonoBehaviour {

    private Rigidbody2D rigid;
    private float vx;
    private float vy;
    private float timer;
    public float delay;
    void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        timer = Time.fixedTime + delay;
    }
	// Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > timer && delay != 0)
        {
            vx = Random.Range(-5f, 5f);
            vy = Random.Range(-5f, 5f);
            rigid.velocity = new Vector2(vx, vy);
            delay = 0;
        }
    }
	void OnCollisionEnter2D (Collision2D col) {
        if (col.contacts == null || col.contacts.Length == 0) return;
        ContactPoint2D contact = col.contacts[0];
        float x = transform.position.x;
        float y = transform.position.y;
        if (Mathf.Abs(x - contact.point.x) > 0.1f)
        {
            if (x > contact.point.x)
            {
                vx = Mathf.Abs(vx);
            }
            else
            {
                vx = vx * -1;
            }
        }
        if (Mathf.Abs(y - contact.point.y) > 0.1f)
        {
            if (y > contact.point.y)
            {
                vy = Mathf.Abs(vy);
            }
            else
            {
                vy = vy * -1;
            }
        }
        rigid.velocity = new Vector2(vx, vy);
    }

}
