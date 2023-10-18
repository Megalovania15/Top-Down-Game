using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float bulletLifetime;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifetime -= Time.deltaTime;

        if (bulletLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
