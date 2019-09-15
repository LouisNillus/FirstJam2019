using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_autodelete : MonoBehaviour
{

    Transform objTransform;

    // Start is called before the first frame update
    void Start()
    {
        objTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(((objTransform.position.y > 8) && (objTransform.position.x > 0 )) || ((objTransform.position.y < -8) && (objTransform.position.x < 0)))
        {
            Destroy(gameObject);
        }
    }
}
