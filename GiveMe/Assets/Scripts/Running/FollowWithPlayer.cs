using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithPlayer : MonoBehaviour
{
    private Transform transform;
    private Transform playerTransform;
    private float offset;
    private void Awake()
    {
        transform = GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable()
    {
        offset = transform.position.x - playerTransform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        var temp = offset + playerTransform.position.x;
        transform.position = new Vector3(temp, transform.position.y, transform.position.z);
    }

}
