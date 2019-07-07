using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer=0f;
    public GameObject player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>5 && Input.anyKeyDown)
        {
            if (player.name == "youth")
                player.GetComponent<Youth>().Move();
            else if (player.name == "adult") player.GetComponent<Adult>().wei();
            Destroy(this.gameObject);
        }
    }
}
