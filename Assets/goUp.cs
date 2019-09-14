using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goUp : MonoBehaviour
{
    private RectTransform rectTransform;
    private const float startPos = -231f;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        rectTransform.localPosition += Vector3.up * (speed * Time.deltaTime);

        if (rectTransform.localPosition.y > 210) rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, startPos, rectTransform.localPosition.z);
    }
}

//des bisous <3