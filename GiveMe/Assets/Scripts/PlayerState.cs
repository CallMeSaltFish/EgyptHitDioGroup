using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    public static bool[] save = new bool[10];

    private static string name="小贱";
    private static int choice =0;
    private static int down = 0;

    public static void Choice()
    {
        choice += (int) Mathf.Pow(2,down);
        down++;
        //PlayerState.save[down] = true;
        Debug.Log("选择次数  "+Convert.ToString(choice));
    }

    public static void SetName(string name)
    {
        PlayerState.name = name; 
    }

    public static string GetName()
    {
        return name;
    }

    public static int GetPoint()
    {
        return choice;
    }
}
