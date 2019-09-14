using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public PostProcessControl ppc;
    public Transform target;
    [Range(0,3)]
    public float delay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TeleportSystem(collision));
        }
    }

    public IEnumerator TeleportSystem(Collider2D collision)
    {
        Controller controller = FindObjectOfType<Controller>();

        controller.allowControl = false;
        IEnumerator bloomRoutine = ppc.BloomTransition(0f, 50f, delay, 3f);

        StartCoroutine(bloomRoutine);
        yield return new WaitForSeconds(delay);

        if (target != null)
        {
            collision.gameObject.transform.position = target.position;
        }

        yield return bloomRoutine;

        controller.allowControl = true;
    }
}