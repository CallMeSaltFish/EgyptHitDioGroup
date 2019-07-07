using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeButton : MonoBehaviour
{
    private GameObject adult;
    private bool able = true;

    // Start is called before the first frame update
    void Start()
    {
        adult = GameObject.Find("adult");
        able = true;
    }


    public void make()
    {
        if (able)
        {
            PlayerState.Choice();
            adult.GetComponent<Adult>().Smile();
            able = false;
        }
    }

    public void dontMake()
    {
        if (able)
        {
            adult.GetComponent<Adult>().Sad();
            able = false;
        }
    }
}
