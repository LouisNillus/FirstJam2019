using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LON_Tools;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MainPack.RBController(this.gameObject, 5, "z", "s", "q", "d");

        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("hooo");
        }
    }
}
