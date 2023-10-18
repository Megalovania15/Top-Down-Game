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
        //float mouseX = Input.GetAxisRaw("Mouse X");
        //float mouseY = Input.GetAxisRaw("Mouse Y");

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.ScreenToWorldPoint(transform.position);

        float mouseX = mousePos.x - objectPos.x;
        float mouseY = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
        //angle -= 90;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        //transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, -angle);

        print(transform.eulerAngles.z - angle);


    }
}
