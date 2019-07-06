using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer=0f;
    private Youth player;

    void Start()
    {
        player = GameObject.Find("youth").GetComponent<Youth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>5 && Input.anyKeyDown)
        {
            player.Move();
            Destroy(this.gameObject);
        }
    }
}
