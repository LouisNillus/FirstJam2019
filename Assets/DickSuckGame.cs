using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DickSuckGame : MonoBehaviour
{
    public PostProcessControl ppc;
    public static int dicksSucked;

    public int points;
    public float time;
    public List<ParticleSystem> myCumPS = new List<ParticleSystem>();
    public List<ParticleSystem> myBloodPS = new List<ParticleSystem>();
    public List<KeyCode> keys;
    private int counter;


    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Controller>().allowControl = false;
            StartSuckingGame();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.A))
        {
            collision.GetComponent<Controller>().allowControl = true;
            StopAllCoroutines();
            CancelInvoke();
            counter = 0;
        }

        if (collision.CompareTag("Player") && Input.GetKeyDown(keys[Random.Range(0, keys.Count)]))
        {
            points++;
        }
    }

    public void StartSuckingGame()
    {
        StartCoroutine(SuckingTime(time));
        InvokeRepeating("BloodSend", 5f, 1f);
    }


    public void BloodSend()
    {
        counter++;
        IEnumerator bloomRoutine = ppc.VignetteTransitionIn(ppc.vignette.intensity, 0.8f, 4f, 3f);

        switch (counter)
        {
            case int n when n <= 4 && n > 0:
                Emitter(2);
                
                break;
            case int n when n <= 8 && n > 4:
                Emitter(6);
                break;
            case int n when n <= 12 && n > 8:
                Emitter(10);
                break;
            case int n when n <= 15 && n > 12:
                Emitter(15);
                break;
        }
    }

    public IEnumerator SuckingTime(float timeToSuck)
    {
        yield return new WaitForSeconds(timeToSuck);
        Debug.Log("Perdu");
        CancelInvoke();
        counter = 0;
    }

    public void Emitter(int max)
    {
        for(int i = 0; i < max; i++)
        {
            myBloodPS[Random.Range(0, myBloodPS.Count)].Emit(1);
        }
    }

}
