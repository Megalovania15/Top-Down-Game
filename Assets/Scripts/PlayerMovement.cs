using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float mouseSensitivity = 100f;
    public float fireRate = 0.2f;

    public Transform shootPoint;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;

    private float maxFireRate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;

        Debug.Log("Spawn time: " + fireRate);

        Move();
        Look();
        Shoot();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.AddForce(new Vector2(moveX, moveY), ForceMode2D.Impulse);
    }

    void Look()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        float mouseX = mousePos.x - objectPos.x;
        float mouseY = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        //transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if(fireRate <= 0)
            {
                Debug.Log("bullets are spawning");
                Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                fireRate = maxFireRate;
            }
            
        }
    }
}
