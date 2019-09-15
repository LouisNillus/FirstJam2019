using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float initSpeed;
    Transform objTransform;
    [SerializeField] Sprite[] spriteArray = new Sprite[2];
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {

        

        rb = GetComponent<Rigidbody2D>();
        objTransform = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();


        if (objTransform.position.x > 0)
        {
            sprite.sprite = spriteArray[0];
            rb.velocity = new Vector2(0, initSpeed*2);
        }
        else
        {
            sprite.sprite = spriteArray[1];
            rb.velocity = new Vector2(0, -initSpeed);
        }
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
