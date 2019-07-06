using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void NewGameDown(){
        SceneManager.LoadScene(1);
    }

    public void ExitDown()
    {
        Application.Quit();
    }
}
