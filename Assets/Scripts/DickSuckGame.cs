using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DickSuckGame : MonoBehaviour
{
    public PostProcessControl ppc;
    public static int dicksSucked;

    public Animator playerAnimator;
    public int scoreToReach;
    public int buttonToPress;
    public Transform buttonPosition;
    public Transform resetGamePosition;
    public int points;
    public float time;
    public List<GameObject> buttons = new List<GameObject>();
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
        if(points >= scoreToReach)
        {
            dicksSucked++;
            foreach(ParticleSystem ps in myCumPS)
            {
                ps.Emit(2);
            }
            points = 0;
        }

        if(dicksSucked == 3)
        {
            Debug.Log("You won !");
            Debug.Log("Allow door");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonToPress = 999;
        if (collision.CompareTag("Player"))
        {
            playerAnimator.SetBool("IsSucking", true);
            playerAnimator.SetBool("IsDown", false);
            playerAnimator.SetBool("IsUp", false);
            playerAnimator.SetBool("IsRight", false);
            playerAnimator.SetBool("IsLeft", false);
            collision.GetComponent<Controller>().allowControl = false;
            StartSuckingGame();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetAxis("Down") < 0f)
        {
            collision.GetComponent<Controller>().allowControl = true;
            StopAllCoroutines();
            CancelInvoke();
            IEnumerator vignetteRoutine = ppc.VignetteTransition(ppc.vignette.intensity, 0f, 15f);
            StartCoroutine(vignetteRoutine);
            counter = 0;
            points = 0;
            playerAnimator.SetBool("IsSucking", false);
            foreach (GameObject go in buttons)
            {
                go.transform.position = new Vector3(500, 500, 0);
            }
        }

        if(buttonToPress == 999)
        {
            buttonToPress = Random.Range(0, keys.Count);
            foreach(GameObject go in buttons)
            {
                go.transform.position = new Vector3(500, 500, 0);
            }
            buttons[buttonToPress].transform.position = buttonPosition.position;
        }
        else if(collision.CompareTag("Player") && Input.GetKeyDown(keys[buttonToPress])) //Bon bouton
        {
            points++;
            buttonToPress = 999;
        }
        else if (collision.CompareTag("Player") && buttonToPress != 999) //Mauvais bouton
        {
            foreach(KeyCode kc in keys)
            {
                if(kc != keys[buttonToPress] && Input.GetKeyDown(kc))
                {
                    points--;
                }
            }
        }
    }

    public void StartSuckingGame()
    {
        StartCoroutine(SuckingTime(time));
        InvokeRepeating("BloodSend", 3f, 1f);
    }


    public void BloodSend()
    {
        counter++;
        IEnumerator vignetteRoutine = ppc.VignetteTransition(ppc.vignette.intensity, 0.6f, 15f);
        StartCoroutine(vignetteRoutine);

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
        IEnumerator vignetteRoutine = ppc.VignetteTransition(ppc.vignette.intensity, 0f, 15f);
        StartCoroutine(vignetteRoutine);
        counter = 0;
        Debug.Log(points);
        points = 0;
        foreach (GameObject go in buttons)
        {
            go.transform.position = new Vector3(500, 500, 0);
        }

        buttonToPress = 999;
        Controller player = FindObjectOfType<Controller>();
        player.transform.position = resetGamePosition.position;
        player.allowControl = true;
        playerAnimator.SetBool("IsSucking", false);
    }

    public void Emitter(int max)
    {
        for(int i = 0; i < max; i++)
        {
            myBloodPS[Random.Range(0, myBloodPS.Count)].Emit(1);
        }
    }
}
