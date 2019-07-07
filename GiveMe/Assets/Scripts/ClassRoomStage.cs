using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomStage : MonoBehaviour
{
    public GameObject laughButton;
    public GameObject helpButton;

    private bool able=true;
    private GameObject youth;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        youth = GameObject.Find("youth");
        able = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)         //放字幕3s后出现选项
        {
            laughButton.SetActive(true);
            helpButton.SetActive(true);
        }
    }

    public void laugh()
    {
        if (able)
        {
            Debug.Log("woc ");
            youth.GetComponent<Youth>().Sad();
            if(this.name=="stage3")
                youth.GetComponent<Youth>().HideStage3();
            else
            youth.GetComponent<Youth>().HideStage2();
            able = false;
        }
    }

    public void help()
    {
        if (able)
        {
            if(this.name=="score") PlayerState.save[5] = true;
            else if (this.name == "stage3") PlayerState.save[6] = true;
            PlayerState.Choice();
            youth.GetComponent<Youth>().Smile();
            if (this.name == "stage3")
                youth.GetComponent<Youth>().HideStage3();
            else
                youth.GetComponent<Youth>().HideStage2();
            able = false;
        }
    }
}
