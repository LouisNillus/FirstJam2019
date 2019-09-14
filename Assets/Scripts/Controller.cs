using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LON_Tools;

public class Controller : MonoBehaviour
{
    [Range(0,10)]
    public int speed;

    public bool allowControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(allowControl == true)
        {
            MainPack.RBController(this.gameObject, speed, "z", "s", "q", "d");
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {

        }
    }
}
