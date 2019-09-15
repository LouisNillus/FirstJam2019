using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_kebab : MonoBehaviour
{

    bool hasMoney = false;
    public GameObject kebab;
    public GameObject text_win;
    public GameObject text_lose;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bin")
        {
            hasMoney = true;
            Debug.Log("has money");
        }
        if (collision.tag == "Kebab")
        {
            if(hasMoney == true)
            {
                Instantiate(kebab);
                Instantiate(text_win);
            }
            else
            {
                Instantiate(text_lose);
            }
        }
    }
}
