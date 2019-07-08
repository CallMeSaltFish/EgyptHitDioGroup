using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float angleSpeed = 10f;

    void Start()
    {
        Screen.fullScreen = false;//这样就可以实现全屏和非全屏间的切换
        Screen.SetResolution(900, 1600, false);//这是设置屏幕分辨率的方法，后面的false表示非全屏
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.forward, Time.deltaTime * angleSpeed);
    }
}
