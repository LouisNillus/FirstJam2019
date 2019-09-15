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
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if(allowControl == true)
        {
            //MainPack.RBController(this.gameObject, speed, "z", "s", "q", "d");
            
            if(xAxis > 0.4f)
            {
                rb.velocity = Vector2.right * speed;
                animator.SetBool("IsRight", true);
                animator.SetBool("IsLeft", false);
            }
            else if(xAxis < -0.4f)
            {
                rb.velocity = Vector2.left * speed;
                animator.SetBool("IsLeft", true);
                animator.SetBool("IsRight", false);
            }
            else
            {
                animator.SetBool("IsLeft", false);
                animator.SetBool("IsRight", false);
            }

            if (yAxis > 0.4f)
            {
                rb.velocity = Vector2.up * speed;
                animator.SetBool("IsUp", true);
                animator.SetBool("IsDown", false);
            }
            else if(yAxis < -0.4f)
            {
                rb.velocity = Vector2.down * speed;
                animator.SetBool("IsDown", true);
                animator.SetBool("IsUp", false);
            }
            else
            {
                animator.SetBool("IsUp", false);
                animator.SetBool("IsDown", false);
            }

        }
    }
}
