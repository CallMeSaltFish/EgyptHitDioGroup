using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private Transform transform;
    private Vector3 targetPosition;
    private void Awake()
    {
        targetPosition = Camera.main.transform.position - new Vector3(0, 5.8f, -10f);
        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
        if(Vector3.Distance(transform.position,targetPosition) <= 0.001f)
        {
            GetComponent<PlayerMove>().enabled = true;
            GetComponentInChildren<Fire>().enabled = true;
            this.enabled = false;
        }
    }
}
