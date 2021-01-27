using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    // private Animator animator;
    public float speed, jumpforce;
    [SerializeField]
    Rigidbody2D rb;

    public GameObject bullet;
    public Vector3 bulletOffset;
    public int healthPts;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");


        if (xPos != 0) //Rotate player sprite to the left
        { GetComponent<SpriteRenderer>().flipX = xPos < 0; }

        //animator.SetFloat("Speed", (Mathf.Abs(xPos) + Mathf.Abs(yPos)) * speed);

        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (xPos == 0 && yPos == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + bulletOffset, transform.rotation);
        }

        if (healthPts <= 0)
        {
            Destroy(gameObject);
           GameplayManager.Instance.ShowGameOver();
        }
        
        if (healthPts == 3)
        {
            GameplayManager.Instance.ShowLife3();
        }

        if (healthPts == 2)
        {
            GameplayManager.Instance.ShowLife2();
        }

        if (healthPts == 1)
        {
            GameplayManager.Instance.ShowLife1();
        }
    }
    public void Test()
    {

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "BulletEnemy")
        {
            healthPts--;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Enemy")
        {
            healthPts--;
        }

        else if (other.gameObject.tag == "Boss")
        {
            healthPts--;
        }
    }
}
