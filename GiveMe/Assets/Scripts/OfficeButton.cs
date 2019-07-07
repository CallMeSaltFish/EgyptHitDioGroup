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
            if(this.name=="Button") PlayerState.save[7] = true;
            else if (this.name == "Button2") PlayerState.save[8] = true;
            else if (this.name == "Button4") PlayerState.save[9] = true;
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
