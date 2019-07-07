using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Born : MonoBehaviour
{
    public GameObject stageOne;
    public GameObject text3;

    private Image color;
    private float alpha = 0f;
    private float timer = 0f;
    private bool down=false;
    private bool over=false;

    void Start()
    {
        color = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) down = true;
        if(down)
        {
            color.color= new Color(255, 255, 255, Mathf.Lerp(0,1,alpha));
            alpha += Time.deltaTime/4;
            if (alpha > 1)
            {
                down = false;
                stageOne.SetActive(true);
            }
        }

        if (over)
        {
            timer += Time.deltaTime;
            if(timer>6)
            SceneManager.LoadScene(2);
        }
    }

    public void OnEndEdit()
    {
       // PlayerState.SetName(str);
        //Debug.Log(str+"??");
        text3.SetActive(true);
        over = true;
    }
}
