using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugButton : MonoBehaviour
{
    private bool able=true;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        able = true;
        player = GameObject.Find("player");
    }

    public void MyButton()
    {
        if (able)
        {
            PlayerState.save[3] = true;
            able = false;
            PlayerState.Choice();
            player.GetComponent<Player>().ShowUp();
            player.GetComponent<Player>().Smile();
        }
    }

    public void SpeakButton()
    {
        if (able)
        {
            able = false;
            player.GetComponent<Player>().ShowUp();
            player.GetComponent<Player>().Cry();
        }
    }
}
