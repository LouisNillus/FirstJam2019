using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LON_Tools;

public class Controller : MonoBehaviour
{
    [Range(0,10)]
    public int speed;

    public bool allowControl;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if(allowControl == true)
        {
            MainPack.RBController(this.gameObject, speed, "z", "s", "q", "d");

            if(xAxis > 0.4f)
            {
                rb.velocity = Vector2.right * speed;
            }
            else if(xAxis < -0.4f)
            {
                rb.velocity = Vector2.left * speed;
            }

            if(yAxis > 0.4f)
            {
                rb.velocity = Vector2.up * speed;
            }
            else if(yAxis < -0.4f)
            {
                rb.velocity = Vector2.down * speed;
            }
        }
    }
}
