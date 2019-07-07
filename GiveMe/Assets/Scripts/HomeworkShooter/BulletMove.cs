using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Transform transform;
    private PlayerMove playerMove;
    private void Awake()
    {
        transform = GetComponent<Transform>();
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        if(transform.name == collision.transform.name)
        {
            collision.gameObject.SetActive(false);
            playerMove.scores += 3;
        }

    }
}
