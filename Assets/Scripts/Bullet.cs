using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bulletspeed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.5f);
        rb.velocity = transform.right * Bulletspeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
