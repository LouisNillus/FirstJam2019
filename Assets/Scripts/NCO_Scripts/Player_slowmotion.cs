using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_slowmotion : MonoBehaviour
{

    [SerializeField] Car_list scrCarList;
    public Car_spawn cspawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("right_trigger") > 0.4f) || (Input.GetKey(KeyCode.Joystick1Button0)))
        {
            Debug.Log("enter");
            foreach(GameObject go in cspawn.activeCarList)
            {
                Rigidbody2D rb = go.GetComponent<Rigidbody2D>();

                switch (rb.velocity.y)
                {
                    case float n when n < 0f:
                        rb.velocity = new Vector2(0, -0.5f);
                        break;
                    case float n when n > 0f:
                        rb.velocity = new Vector2(0, 0.5f);
                        break;
                }
            }
        }
        else
        {
            foreach (GameObject go in cspawn.activeCarList)
            {
                Rigidbody2D rb = go.GetComponent<Rigidbody2D>();

                switch (rb.velocity.y)
                {
                    case float n when n < 0f:
                        rb.velocity = new Vector2(0, -8f);
                        break;
                    case float n when n > 0f:
                        rb.velocity = new Vector2(0, 8);
                        break;
                }
            }
        }

    }
}
