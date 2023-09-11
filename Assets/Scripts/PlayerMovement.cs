using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float mouseSensitivity = 100f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.AddForce(new Vector2(moveX, moveY), ForceMode2D.Impulse);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float angle = Mathf.Atan2(mouseX, mouseY) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, -angle);

        print(transform.eulerAngles.z - angle);
    }
}
