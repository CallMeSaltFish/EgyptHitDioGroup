using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    private int point;
    private int bit;
    private int ans=0;

    private SpriteRenderer spriteRenderer;
    private Texture2D texture;
    private Rect rect;

    private Sprite most;
    private Sprite more;
    private Sprite less;
    private Sprite least;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void calculate()
    {
        while (point > 0)
        {
            bit=point % 2;
            point = point / 2;
            ans += bit;
        }
    }
}
