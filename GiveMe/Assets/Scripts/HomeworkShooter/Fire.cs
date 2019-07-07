using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    private float time;
    private const float limitTime = 0.6f;
    private static string firedBullte = "Q";
    [SerializeField]
    private Sprite[] sprites;

    private Image show;
    private int num;
    private void Awake()
    {
        show = GameObject.Find("Canvas/Show").GetComponent<Image>();
        num = 0;
    }
    // Update is called once per frame
    void Update()
    {
        ChoseBullet();
        OpenFire();
    }

    void OpenFire()
    {
        time += Time.deltaTime;
        if(time > limitTime && Input.GetMouseButtonDown(0))
        {
            time = 0;
            var temp = BulletPool._instance.GetPooledGameObject(firedBullte);
            if(temp != null)
            {
                temp.SetActive(true);
                temp.transform.position = transform.position;
            }
        }
    }

    void ChoseBullet()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    firedBullte = "Q";
        //    show.sprite = sprites[0];
        //    StartCoroutine(ShowFlash());
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    firedBullte = "W";
        //    show.sprite = sprites[1];
        //    StartCoroutine(ShowFlash());
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    firedBullte = "E";
        //    show.sprite = sprites[2];
        //    StartCoroutine(ShowFlash());
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    firedBullte = "R";
        //    show.sprite = sprites[3];
        //    StartCoroutine(ShowFlash());
        //}
        if(Input.GetMouseButtonDown(1))
        {
            num++;
            switch(num % 4)
            {
                case 0:
                    firedBullte = "Q";
                    show.sprite = sprites[0];
                    break;
                case 1:
                    firedBullte = "W";
                    show.sprite = sprites[1];
                    break;
                case 2:
                    firedBullte = "E";
                    show.sprite = sprites[2];
                    break;
                case 3:
                    firedBullte = "R";
                    show.sprite = sprites[3];
                    break;
            }
            StartCoroutine(ShowFlash());
        }
    }

    IEnumerator ShowFlash()
    {
        Color color = Color.white;
        for(float i = 1; i >= 0.3f; i -= 0.05f)
        {
            color.a = i;
            show.color = color;
            yield return 0;
        }
        for(float i = 0.3f; i <= 1.01f; i += 0.05f)
        {
            color.a = i;
            show.color = color;
            yield return 0;
        }
    }
}
