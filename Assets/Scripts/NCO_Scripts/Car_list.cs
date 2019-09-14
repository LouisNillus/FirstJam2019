using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Car_list : MonoBehaviour
{

    public List<GameObject> CarList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Car"))
        {
            CarList.Add(fooObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
