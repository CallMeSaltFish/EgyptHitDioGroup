﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeStageOne : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        if(timer>8)
        {
            Button1.SetActive(true);
            Button2.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
