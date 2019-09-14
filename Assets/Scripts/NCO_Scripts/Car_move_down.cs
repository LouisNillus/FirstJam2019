using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_move_down : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] int initSpeed;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, initSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(0, speed);
    }

}
