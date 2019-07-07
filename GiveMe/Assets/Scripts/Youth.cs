using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Youth : MonoBehaviour
{
    public GameObject makeButton;
    public GameObject dontMakeButton;
    public GameObject Stage2;
    public GameObject Stage3;

    private bool game = false;
    private float timer = -1f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Texture2D texture;
    private Rect rect;

    private Sprite youthIdle;
    private Sprite youthHappy;
    private Sprite youthSad;

    private GameObject homeWorkShooter;

    // Start is called before the first frame update
    void Start()
    {
        homeWorkShooter = Resources.Load("Prefabs/homeWorkShooter") as GameObject;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rect = new Rect(0, 0, 286, 1036);
        texture = Resources.Load("Sprites/player/youthHappy") as Texture2D;
        youthHappy = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/player/youthSad") as Texture2D;
        youthSad = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/player/youthIdle") as Texture2D;
        youthIdle = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
    }

    public void Move()
    {
        animator.SetTrigger("walk");
    }

    public void HideStage2()
    {
        Destroy(Stage2.gameObject);
    }

    public void HideStage3()
    {
        Destroy(Stage3.gameObject);
    }

    public void GameWin()
    {
        Stage2.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer > 4 && timer < 5)
            {
                if (Stage2 != null)
                {
                    if (!game)
                    {
                        game = true;
                        GameObject.Instantiate(homeWorkShooter);
                        //Stage2.SetActive(true);
                        Destroy(makeButton.gameObject);
                        Destroy(dontMakeButton.gameObject);
                    }
                }
                else
                {
                    if (Stage3 != null)
                        Stage3.SetActive(true);
                    else SceneManager.LoadScene(4);
                }
            }
        }
    }

    public void Smile()
    {
        spriteRenderer.sprite = youthHappy;
        timer = 0f;
    }

    public void Sad()
    {
        spriteRenderer.sprite = youthSad;
        timer = 0f;
    }

    public void ShowFriendsOption() {
        makeButton.SetActive(true);
        dontMakeButton.SetActive(true);
     }
}
