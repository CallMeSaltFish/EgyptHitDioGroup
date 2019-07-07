using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoOn : MonoBehaviour
{
    private Button button;
    private GameObject player;
    private void Awake()
    {
        button = GetComponent<Button>();
        player = GameObject.FindWithTag("Player");
        button.onClick.AddListener(() =>
        {
            //Time.timeScale = 1;
            player.GetComponent<PlayerControl>().enabled = true;
            player.GetComponent<Animator>().enabled = true;
            GameObject.FindWithTag("Meow").GetComponent<MeowMove>().enabled = true;
            button.gameObject.SetActive(false);
        });
    }
}
