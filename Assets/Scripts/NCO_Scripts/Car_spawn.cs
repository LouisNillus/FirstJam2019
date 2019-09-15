using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Car_spawn : MonoBehaviour
{

    float delay;
    int carSelector, spawnColumn; // randoms
    [SerializeField] int maxCarsOnScreen, spawnLine;
    List<GameObject> prefabCarList = new List<GameObject>();
    [SerializeField] Car_list scrCarList;
    List<GameObject> activeCarList = new List<GameObject>(); // public ?
    //[SerializeField] List<int> columnList = new List<int>();
    [SerializeField] Transform[] columnArray = new Transform[8];

    // Start is called before the first frame update
    void Start()
    {
        // ensemble des voitures dispo
        prefabCarList = scrCarList.prefabCarList;
        InvokeRepeating("GenerateCar", 0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        carSelector = Random.Range(0, prefabCarList.Count);


        spawnColumn = Random.Range(0,8);

    }

    IEnumerator SpawnNewCar()
    {
        delay = Random.Range(0, 1);
            GameObject newCar = Instantiate(prefabCarList[carSelector], columnArray[spawnColumn]);
            activeCarList.Add(newCar);
            Debug.Log("instance created");
            Debug.Log(activeCarList[0]);

        yield return new WaitForSeconds(delay);
    }

    public void GenerateCar()
    {
        StartCoroutine(SpawnNewCar());
    }

}
