using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour {
    public int HP;
    public string[] BulletTags = new string[0];//Bullets tagged with this will damage object
    public GameObject enemyExplosion;
    public float invincibilityCooldown = 0;
    public GameObject effect;
    public AudioClip explosion;
    public float explosionVolume;
    public AudioClip bulletSound;
    public float bulletVolume;

    private float timer;
    private bool invincible = false;
    private ParticleSystem ps;
    public float particleSpeed = 1.0f;

    //Todo enemies don't get invulnerability

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (ps != null)
        {
            var main = ps.main;
            main.simulationSpeed = particleSpeed;
        }
        if (Time.fixedTime < timer)
        {
            invincible = true;
        }
        else
        {
            invincible = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string Coltag = collision.gameObject.tag;
        foreach (string tag in BulletTags) {
            if (Coltag == tag && !invincible)
            {
                HealthDecreasing(collision);
            }
        }
    }

    private void HealthDecreasing(Collision2D collision)
    {
        Debug.Log("Hit!");
        Debug.Log(HP);
        HP -= 1;
        timer = Time.fixedTime + invincibilityCooldown;

     

        if (HP <= 0)
        {
            if (this.tag == "Player")
            {
                SceneManager.LoadScene("LoseScreen");
            }
            if (this.tag == "Boss")
            {
                SceneManager.LoadScene("Win_Screen");
            }
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(explosion, transform.position, explosionVolume);
            GameObject explode = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(explode, 1.0f);
        }
        GameObject bulletDespawn = (Instantiate(effect, transform.position, Quaternion.identity) as GameObject);
        AudioSource.PlayClipAtPoint(bulletSound, transform.position, bulletVolume);
        Destroy(collision.gameObject);

        Debug.Log("Enemies remaining: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("go to boss");
        }
    }
}

/*
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
	{
		Debug.Log ("Level load requested for " + name);
		Application.LoadLevel(name);
	}

	public void QuitRequest()
	{
		Debug.Log("I want to quit!");
		Application.Quit ();
	}

	public void LoadNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
 */
