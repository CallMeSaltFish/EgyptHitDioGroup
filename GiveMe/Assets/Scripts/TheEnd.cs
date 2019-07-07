using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour
{
    public Text text;
    public GameObject move;

    public GameObject nameList;
    private float stratX;
    private float stratY;
    private float t = 0;
    private int point;
    private int bit;
    private int ans=0;
    private string tmpStr;

    private SpriteRenderer spriteRenderer;
    private Texture2D texture;
    private Rect rect;

    private Sprite most;
    private Sprite more;
    private Sprite less;
    private Sprite least;

    private GameObject canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        spriteRenderer = GetComponent<SpriteRenderer>();
        point = PlayerState.GetPoint();
        rect = new Rect(0, 0, 1080, 1920);
        texture = Resources.Load("Sprites/pointMost") as Texture2D;
        most = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/pointMore") as Texture2D;
        more = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/pointLess") as Texture2D;
        less = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/pointLeast") as Texture2D;
        least = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        calculate();
        text.text = text.text.Replace("小剑", PlayerState.GetName());
        if (ans <= 2)
        {
            spriteRenderer.sprite = least;
        }
        else if (ans <= 4)
        {
            spriteRenderer.sprite = less;
        }
        else if (ans <= 6)
        {
            spriteRenderer.sprite = more;
        }
        else
        {
            spriteRenderer.sprite = most;
        }

        stratX = move.transform.position.x;
        stratY = move.transform.position.y;
    }

    private void calculate()
    {
        for (int i=1;i<=9;i++)
        {
            bit=point % 2;
            point = point / 2;
            ans += bit;
            if (bit > 0) text.text = text.text.Replace(Convert.ToString(i), Words.words1[i]);
            else text.text = text.text.Replace(Convert.ToString(i), Words.words2[i-1]);
        }
    }

    private void Update()
    {
        t += Time.deltaTime/60;
        if (Input.GetMouseButtonDown(0)) t += 0.1f;
        move.transform.position = new Vector2(stratX, Mathf.Lerp(stratY, stratY + 4000, t));
        if (t >= 1) {

            Destroy(canvas);
            nameList.SetActive(true);
            Destroy(this);
        }
    }
}
