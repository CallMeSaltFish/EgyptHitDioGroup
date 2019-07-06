using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youth : MonoBehaviour
{
    private float timer = 0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Move()
    {
        animator.SetTrigger("walk");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}
