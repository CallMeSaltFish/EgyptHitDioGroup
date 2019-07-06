using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomStage : MonoBehaviour
{
    public GameObject laughButton;
    public GameObject helpButton;

    private bool able=false;
    private GameObject youth;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        youth = GameObject.Find("youth");
        able = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            laughButton.SetActive(true);
            helpButton.SetActive(true);
        }
    }

    public void laugh()
    {
        if (able)
        {        
            youth.GetComponent<Youth>().Sad();
            youth.GetComponent<Youth>().HideStage2();
            able = false;
        }
    }

    public void help()
    {
        if (able)
        {
            PlayerState.Choice();
            youth.GetComponent<Youth>().Smile();
            youth.GetComponent<Youth>().HideStage2();
            able = false;
        }
    }
}
