using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour,IPointerClickHandler
{
    public GameObject dialogBox;
    public GameObject childSleep;
    public GameObject hugButton;
    public GameObject talkButton;

    private Image image;

    private int wakeUpTime=0;
    private float timer = 0f;
    private float changeTimer = -1f;

    private Texture2D texture;
    private Rect rect;

    private Sprite childIdle;
    private Sprite childHappy;
    private Sprite childSad;

    private BackGroundManage backGround;

    private void Awake()
    {
        childSleep.SetActive(true);
        dialogBox.SetActive(false);
        hugButton.SetActive(false);
        talkButton.SetActive(false);
        image = this.GetComponent<Image>();
        image.enabled=false;
        backGround = GameObject.Find("backGround").GetComponent<BackGroundManage>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        if((backGround.chooseColaOrMilk==1 && backGround.GetId()==1)||(backGround.chooseColaOrMilk==2 &&backGround.GetId()==2) )
            image.sprite = childHappy;
        else 
                image.sprite = childSad;

        backGround.GetComponent<BackGroundManage>().chooseColaOrMilk = 0;
        Destroy(GameObject.FindGameObjectWithTag("object"));
        dialogBox.SetActive(false);
        timer = -5f;
    }

    public void Smile() //此button事件结束后，场景切换
    {
        image.sprite = childHappy;
        changeTimer = 0f;
    }

    public void Cry()
    {
        image.sprite = childSad;
        changeTimer = 0f;
    }

    void Start()
    {
        rect = new Rect(0, 0, 1080, 1920);
        texture = Resources.Load("Sprites/player/childHappy") as Texture2D;
        childHappy = Sprite.Create(texture, new Rect(0, 0, 420, 317), new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/player/childSad") as Texture2D;
        childSad = Sprite.Create(texture, new Rect(0, 0, 420, 317), new Vector2(0.5f, 0.5f));

        texture = Resources.Load("Sprites/player/childIdle") as Texture2D;
        childIdle = Sprite.Create(texture, new Rect(0, 0, 420, 317), new Vector2(0.5f, 0.5f));

        image.sprite = childIdle;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 7 && image.enabled==false) //7s之前在睡觉
        {
            wakeUp(++wakeUpTime);
        }
        if (timer > 0 && timer<7  && image.enabled == true)
        {
            sleep();
        }

        if (changeTimer >= 0)    //场景切换
        {
            changeTimer += Time.deltaTime;
            if (changeTimer > 5) SceneManager.LoadScene(3);
        }
    }

    private void sleep()        //image is wakeUp
    {
        image.enabled = false;
        childSleep.SetActive(true);
    }

    private void wakeUp(int k)
    {
        Debug.Log(k);
        if (k <= 2) backGround.GetComponent<BackGroundManage>().WakeUp();
        else BaoBao();
        childSleep.SetActive(false);
        image.enabled = true;
        dialogBox.SetActive(true);
        dialogBox.GetComponent<dialogBox>().Show(k);
    }

    private void BaoBao()
    {
        talkButton.SetActive(true);
        hugButton.SetActive(true);
    }
}
