using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject laser;
    public GameObject playerObject;
    public float fireRate;
    public Sprite[] gunSprites;
    public Sprite[] laserSprites;

    private float timer;

    private int colorNumber = 1;
    private int spriteIndex;
    private int laserIndex;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        ChangeFrequency();
        LoadSprites();

    }

    void red()
    {
        spriteIndex = 0;
        laserIndex = 0;
    }

    void green()
    {
        spriteIndex = 1;
        laserIndex = 1;
    }

    void yellow()
    {
        spriteIndex = 2;
        laserIndex = 2;
    }

    void blue()
    {
        spriteIndex = 3;
        laserIndex = 3;
    }

    void ChangeFrequency()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            colorNumber++;
            if (colorNumber > 4)
            {
                colorNumber = 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            colorNumber--;
            if (colorNumber < 1)
            {
                colorNumber = 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            colorNumber++;
            if (colorNumber > 4)
            {
                colorNumber = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            colorNumber++;
            if (colorNumber > 4)
            {
                colorNumber = 1;
            }
        }

        switch (colorNumber)
        {
            case 1:
                red();
                break;
            case 2:
                green();
                break;
            case 3:
                yellow();
                break;
            case 4:
                blue();
                break;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            spriteIndex = 0;
            laserIndex = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            spriteIndex = 1;
            laserIndex = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            spriteIndex = 2;
            laserIndex = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            spriteIndex = 3;
            laserIndex = 3;
        }

    }
    void LoadSprites()
    {
        if (spriteIndex >= 0 && spriteIndex < gunSprites.Length && gunSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = gunSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite " + spriteIndex + " not found");
        }
        if (laserIndex >= 0 && laserIndex < laserSprites.Length && laserSprites[laserIndex])
        {
            laser.GetComponent<SpriteRenderer>().sprite = laserSprites[laserIndex];
        }
    }

    void Fire()
    {
        if (Input.GetMouseButton(0) && (Time.fixedTime > timer))
        {
            timer = Time.fixedTime + fireRate;

            GameObject bullet;
            Vector3 bulletLocation = new Vector3(transform.position.x, transform.position.y, 0);
            Vector3 delta = bulletLocation - transform.parent.position;
            float z = playerObject.transform.rotation.z;
            bulletLocation += delta.normalized * .5f;
            bullet = (Instantiate(laser, bulletLocation, Quaternion.Euler(0, 0, 0))) as GameObject;
            bullet.layer = laserIndex + 10;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = -transform.right * 10;
            rb.rotation = playerObject.GetComponent<Rigidbody2D>().rotation;
            Destroy(bullet, 1.0f);
        }
    }
}
