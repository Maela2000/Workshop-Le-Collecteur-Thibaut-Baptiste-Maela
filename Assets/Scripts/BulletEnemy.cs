using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float Bulletspeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        if (Horizontal != 0) //Rotate player sprite to the left        
        {
            GetComponent<SpriteRenderer>().flipX = Horizontal < 0;
        }
        transform.Translate(Vector3.left * Bulletspeed * Time.deltaTime);
    }
}
