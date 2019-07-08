using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameList : MonoBehaviour
{
    public GameObject mostButton;
    public GameObject moreButton;
    public GameObject lessButton;
    public GameObject leastButton;
    private float timer = 0f;
    private bool ok = false;
    private int ans;

    public void SetAns(int k)
    {
        this.ans = k;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4 && !ok)
        {
            if (Input.anyKeyDown)
            {
                ok = true;
                Destroy(GameObject.Find("theEnd"));
                if (ans <= 2)
                {
                    leastButton.SetActive(true);
                }
                else if (ans <= 4)
                {
                    lessButton.SetActive(true);
                }
                else if (ans <= 6)
                {
                    moreButton.SetActive(true);
                }
                else
                {
                    mostButton.SetActive(true);
                }
            }
        }
    }
}
