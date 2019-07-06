using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    private static string name;
    private static int choice =0;
    private static int down = 0;

    public static void Choice()
    {
        choice += (int) Mathf.Pow(2,down);
        down++;
        Debug.Log(choice);
    }

    public static void SetName(string name)
    {
        PlayerState.name = name; 
    }

}
