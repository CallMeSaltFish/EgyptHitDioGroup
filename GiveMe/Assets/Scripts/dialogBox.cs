﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogBox : MonoBehaviour
{
    public GameObject cola;
    public GameObject robot;
    public GameObject hug;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //cola.SetActive(false);
        //robot.SetActive(false);
    }

    public void Show(int k)
    {
        if (k == 1)
        {
            cola.SetActive(true);
            robot.SetActive(false);
            hug.SetActive(false);
        }
        else if (k == 2)
        {
            cola.SetActive(false);
            robot.SetActive(true);
            hug.SetActive(false);
        }
        else if (k == 3)
        {
            spriteRenderer.enabled = false;
            cola.SetActive(false);
            robot.SetActive(false);
            hug.SetActive(true);
        }
    }

}
