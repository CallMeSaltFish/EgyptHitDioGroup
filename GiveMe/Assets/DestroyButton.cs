﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
