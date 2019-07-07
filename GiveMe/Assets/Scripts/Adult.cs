using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Adult : MonoBehaviour
{
    public GameObject okButton;
    public GameObject notButton;
    public GameObject okButton1;
    public GameObject notButton1;
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;

    private float timer = -1f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Texture2D texture;
    private Rect rect;

    private Sprite youthIdle;
    private Sprite youthHappy;
    private Sprite youthSad;
    private bool stop=false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rect = new Rect(0, 0, 282, 1042);
        texture = Resources.Load("Sprites/player/adultHappy") as Texture2D;
        youthHappy = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/player/adultSad") as Texture2D;
        youthSad = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/player/adultIdle") as Texture2D;
        youthIdle = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
    }

    public void wei() //唤醒timer
    {
        timer = 0f;
    }

    public void HideStage3()
    {
        Destroy(Stage3.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            if (!stop) timer += Time.deltaTime;
            if(timer>2f&& Stage1 != null && !Stage1.activeSelf )
            {
                Stage1.SetActive(true);
                stop = true;
            }
            if (timer > 4 && Stage1 == null && Stage2 != null && !Stage2.activeSelf)
            {
                Stage2.SetActive(true);
                Destroy(okButton.gameObject);
                Destroy(notButton.gameObject);
                stop = true;
                timer = 0;
            }
            if (timer > 4 && Stage1 == null && Stage2 == null && Stage3 != null && !Stage3.activeSelf)
            {
                Stage3.SetActive(true);
                Destroy(okButton1.gameObject);
                Destroy(notButton1.gameObject);
                stop = true;
                timer = 0;
            }
            if (timer > 4 && Stage1 == null && Stage2 == null && Stage3 == null)
            {
                SceneManager.LoadScene(5);
            }
        }
    }

    public void Smile()
    {
        spriteRenderer.sprite = youthHappy;
        timer = 0f;
        stop = false;
    }

    public void Sad()
    {
        spriteRenderer.sprite = youthSad;
        timer = 0f;
        stop = false;
    }

    public void ShowFriendsOption()
    {
        okButton.SetActive(true);
        notButton.SetActive(true);
    }
}
