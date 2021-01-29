using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Enemyspeed;
    public int healthPts;
    public float move;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    public GameObject bulletEnemy;
    public Transform pointfire;
    public Transform pointfire2;
    private Transform target;
    public Transform[] moveSpots;//creation of gameobject which will serve as indicators


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxis("Horizontal");

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Enemyspeed * Time.deltaTime);//the player random move between the different gameobjects
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (healthPts <= 0)
        {
            GameplayManager.Instance.Score += 125;
            Destroy(gameObject);
        }

        if (xPos != 0) //Rotate player sprite to the left
        { GetComponent<SpriteRenderer>().flipX = xPos < 0; }

        FollowTarget();
    }

    void SpawnBullet()
    {
        Instantiate(bulletEnemy, pointfire.position, pointfire.rotation);
        Instantiate(bulletEnemy, pointfire2.position, pointfire2.rotation);
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Enemyspeed * Time.deltaTime);//The enemy follow the player
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //the enemy 
        {
            InvokeRepeating("SpawnBullet", 1.0f, 6.0f);
            Enemyspeed = Enemyspeed- move;
            target = collision.transform;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //If the enemy touch boxcollider's player, it lose health
        {
            healthPts--;
        }


        if (collision.gameObject.tag == "Bullet")//If the enemy touch boxcollider's bullet, it lose health
        {
            healthPts--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BulletG")//If the enemy touch boxcollider's bullet, it lose health
        {
            healthPts= healthPts-5;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//the enemy
    {
        if (collision.tag == "Player")
        {
            CancelInvoke("SpawnBullet");
            Enemyspeed = Enemyspeed + move;
            target = null;
        }
    }
}
