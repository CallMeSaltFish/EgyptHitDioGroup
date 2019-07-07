using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class MyTextChar : MonoBehaviour
{

    private Text uiText;

    //储存中间值
    private string words;
    //每个字符的显示速度
    private float timer;
    private float timer2;
    //限制条件，是否可以进行文本的输出
    private bool isPrint = false;
    public float perCharSpeed = 10;

    // Use this for initialization

    void Start()
    {
        uiText = GetComponent<Text>();
        words = GetComponent<Text>().text;
        //words = GetComponent<Text>().text.Replace("小剑", PlayerState.GetName());
        Debug.Log(words);
        isPrint = true;
    }

    // Update is called once per frame
    void Update()
    {

        printText();
    }

    void printText()
    {
        try
        {
            if (isPrint)
            {

                uiText.text = words.Substring(0, (int)(perCharSpeed * timer));//截取

                timer += Time.deltaTime;

            }
        }
        catch (System.Exception)
        {
            printEnd();
        }
    }

    void printEnd()
    {
        isPrint = false;
    }
}