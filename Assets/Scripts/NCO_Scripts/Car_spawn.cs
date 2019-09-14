using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Car_spawn : MonoBehaviour
{

    int delay;
    Transform objTransform;

    public List<GameObject> activeCarList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        objTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    /*void Update()
    {
        delay = Random.Range(3, 5);
        ranCar = 
    }
    
    IEnumerator SpawnCar()
    {

        activeCarList.Add(new carList[ranCar].instan);

        yield return new WaitForSeconds(delay);
        
    }*/

}
