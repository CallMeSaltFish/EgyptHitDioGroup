using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManage : MonoBehaviour
{
    public GameObject marketCanvas;
    public GameObject marketButton;
    public GameObject backButton;
    public int chooseColaOrMilk=0;

    private GameObject running;
    private int id = 0;
    private GameObject livingRoomCanvas;
    private SpriteRenderer spriteRenderer;
    private Texture2D texture;
    private Rect rect;

    private GameObject mouse;
    private Sprite milk;
    private Sprite cola;
    private Sprite robot;
    private Sprite soccer;
    private Sprite market;
    private Sprite market2;
    private Sprite livingRoom;
    private Sprite classRoom;

    public int GetId()
    {
        return id;
    }

    public void WakeUp()
    {
        marketButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Awake()
    {
        running = Resources.Load("Prefabs/Running") as GameObject;
        marketCanvas.SetActive(false);
        marketButton.SetActive(false);
        //marketButton.onClick.AddListener(GoMarket);
        livingRoomCanvas = GameObject.Find("livingRoomCanvas");

        rect = new Rect(0, 0, 1080, 1920);
        texture = Resources.Load("Sprites/livingRoom") as Texture2D;
        livingRoom=Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/classRoom") as Texture2D;
        classRoom = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/market") as Texture2D;
        market = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/market2") as Texture2D;
        market2 = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/marketMilk") as Texture2D;
        milk = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/marketCola") as Texture2D;
        cola = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/marketSoccer") as Texture2D;
        soccer = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/marketRobot") as Texture2D;
        robot = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = livingRoom;
    }

    #region ChoiceEffect

    public void backMarket()
    {
        if(id==1)  spriteRenderer.sprite = market;
        else if (id == 2) spriteRenderer.sprite = market2;
    }

    public void milkButton()
    {
        if (id==1) spriteRenderer.sprite = milk;
        else if (id == 2) spriteRenderer.sprite = robot;
    }

    public void colaButton()
    {
        if(id==1)  spriteRenderer.sprite = cola;
        else if(id==2) spriteRenderer.sprite = soccer;
    }

    #endregion


    void Update()
    {
        if (chooseColaOrMilk > 0)  //已经选择了饮料
        {
            mouse.transform.position = Camera.main.ScreenToWorldPoint
                (Input.mousePosition + new Vector3(0, 0, Camera.main.farClipPlane));     
        }
    }

    public void milkButtonDown()
    {
        GameObject tmp;

        if (chooseColaOrMilk == 0)
        {
            chooseColaOrMilk = 2;
            backButton.SetActive(true);
            if (id == 2)
            {
                PlayerState.save[2] = true;
                tmp = Resources.Load("Prefabs/robot") as GameObject;
                PlayerState.Choice();
            }
            else tmp = Resources.Load("Prefabs/milk") as GameObject;
            
            mouse = GameObject.Instantiate(tmp,
                Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.farClipPlane)), Quaternion.identity);
        }
    }

    public void colaButtonDown() //cola||soccer
    {
        GameObject tmp;
        

        if (chooseColaOrMilk == 0)
        {
            chooseColaOrMilk = 1;
            backButton.SetActive(true);
            if (id == 1)
            {
                PlayerState.save[1] = true;
                tmp = Resources.Load("Prefabs/cola") as GameObject;
                PlayerState.Choice();
            }
            else
            {
                tmp = Resources.Load("Prefabs/soccer") as GameObject;
            }
            
            mouse = GameObject.Instantiate(tmp,
                Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.farClipPlane)), Quaternion.identity);
        }
    }










    public void backButtonDown()  //绑定的back
    {
        marketCanvas.SetActive(false);
        livingRoomCanvas.SetActive(true);
        marketButton.SetActive(false);
        spriteRenderer.sprite = livingRoom;
    }

    public void MarketButton()
    {
        GameObject.Instantiate(running);
        AudioSource audio = GameObject.FindWithTag("AudioSource").GetComponent<AudioSource>();
        audio.Pause();
        livingRoomCanvas.SetActive(false);
    }

    public  void GameFail()
    {
        livingRoomCanvas.SetActive(true);
    }

    public void GoMarket()  //绑定的market
    {

        //GameObject.Instantiate(running);
        id++;
        spriteRenderer.sprite = market;
        marketCanvas.SetActive(true);
        livingRoomCanvas.SetActive(false);
    }
}
