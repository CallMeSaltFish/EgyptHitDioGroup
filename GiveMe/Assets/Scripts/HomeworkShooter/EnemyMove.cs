using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public bool isPingpong;
    public float speed;
    private PlayerMove playerMove;

    private int index;
    private void Awake()
    {
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        index = Random.Range(-3, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 2f * Time.deltaTime);
        //transform.Rotate(0, 0, 10 * speed);
        Pingpong();
        //Debug.Log(Mathf.PingPong(Time.time, 4.8f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);
            playerMove.scores -= 2;
            if (playerMove.scores < 0)
            {
                playerMove.scores = 0;
            }
        }
    }

    void Pingpong()
    {
        if (isPingpong)
        {
            if (Mathf.Abs(index) % 2 == 1)
            {
                //Debug.Log("Here");
                transform.Translate(Vector3.right * index * Time.deltaTime);
                if(transform.position.x >= 4.8f || transform.position.x <= -4.8f)
                {
                    index *= -1;
                }
                //var temp = transform.position;
                //temp.x = Mathf.PingPong(Time.time * 0.75f, 4.8f) - 2.4f;
                //transform.position = temp;
            }
        }
    }
}
