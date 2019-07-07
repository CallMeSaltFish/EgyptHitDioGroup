using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowMove : MonoBehaviour
{
    private Transform transform;
    [SerializeField]
    private float speed;
    private void Awake()
    {
        transform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
