using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugButton : MonoBehaviour
{

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    public void MyButton()
    {
        PlayerState.Choice();
        player.GetComponent<Player>().Smile();
    }

    public void SpeakButton()
    {
        player.GetComponent<Player>().Cry();
    }
}
