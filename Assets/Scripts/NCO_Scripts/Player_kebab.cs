using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_kebab : MonoBehaviour
{
    bool canClick = false;
    bool hasMoney = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button0) && (canClick == true) && (hasMoney == false))
        {
            // Instantiate();
            hasMoney = true;
            Debug.Log("has money");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Bin") || (other.tag == "Chef"))
        {
            canClick = true;
            Debug.Log("can click");
        }
    }
}
