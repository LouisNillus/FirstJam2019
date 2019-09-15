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
    public List<GameObject> activeCarList = new List<GameObject>(); // public ?
    //[SerializeField] List<int> columnList = new List<int>();
    [SerializeField] Transform[] columnArray = new Transform[8];
    bool timeSlowed = false;
    public Player_slowmotion manaScript;

    // Start is called before the first frame update
    void Start()
    {
        // ensemble des voitures dispo
        prefabCarList = scrCarList.prefabCarList;
        InvokeRepeating("GenerateCar", 0f, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey(KeyCode.Joystick1Button0)) && (timeSlowed == false) && (manaScript.mana > 0))
        {
            CancelInvoke();
            InvokeRepeating("GenerateCar", 0f, 1f);
            timeSlowed = true;
        }


        if ((!Input.GetKey(KeyCode.Joystick1Button0)) && (timeSlowed == true))
        {
            CancelInvoke();
            InvokeRepeating("GenerateCar", 0f, 0.3f);
            timeSlowed = false;
        }



            carSelector = Random.Range(0, prefabCarList.Count);
        spawnColumn = Random.Range(0,8);
        

        for(int i = 0; i < activeCarList.Count; i++)
        {
            if(activeCarList[i] == null)
            {
                activeCarList.Remove(activeCarList[i]);
            }
        }

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
