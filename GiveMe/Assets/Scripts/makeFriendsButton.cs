using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeFriendsButton : MonoBehaviour
{
    private GameObject youth;
    private bool able = true;

    // Start is called before the first frame update
    void Start()
    {
        youth = GameObject.Find("youth");
        able = true;
    }


    public void make()
    {
        if (able)
        {
            PlayerState.Choice();
            youth.GetComponent<Youth>().Smile();
            able = false;
        }
    }

    public void dontMake()
    {
        if (able)
        {
            youth.GetComponent<Youth>().Sad();
            able = false;
        }
    }
}
