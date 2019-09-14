using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomGame : MonoBehaviour
{
    [SerializeField]
    private float chosenDelay;
    [SerializeField]
    private const int reached = 65;

    [Min(0), Range(0, 100)]
    public int value = 0;

    [Range(0, 10)]
    public int malus;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LowerItFunc",0,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(value < reached)
        {
            Steps();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {          
            value++;
        }
    }

    public IEnumerator LowerIt()
    {
        yield return new WaitForSeconds(chosenDelay);
        value -= malus;
    }

    public void LowerItFunc()
    {
        StartCoroutine(LowerIt());
    }

    public void Steps()
    {
        switch(value)
        {
            case 0:
                malus = 0;
                break;
            case int n when (n < 10 && n >= 0):
                malus = 1;
                break;
            case int n when (n < 30 && n >= 10):
                malus = Random.Range(1,3);
                break;
            case int n when (n < 60 && n >= 30):
                malus = Random.Range(1,4);
                break;
            case int n when n >= 60:
                malus = 0;
                CancelInvoke();                
                break;
        }
    }
}
