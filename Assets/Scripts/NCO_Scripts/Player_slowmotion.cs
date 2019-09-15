using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_slowmotion : MonoBehaviour
{

    [SerializeField] Car_list scrCarList;
    public Car_spawn cspawn;
    public int mana = 150;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Joystick1Button0)) && (mana > 0)) 
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
                        rb.velocity = new Vector2(0, 16);
                        break;
                }
            }
        }

        image.fillAmount = ((1f/150f*mana));

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            mana--;
        }
        if (mana < 0)
        {
            mana = 0;
        }
    }

}
