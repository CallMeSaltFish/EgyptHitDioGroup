using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColaButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject backGround;
    private Sprite s;

    private void Awake()
    {
        backGround = GameObject.Find("backGround");
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        backGround.GetComponent<BackGroundManage>().colaButton();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backGround.GetComponent<BackGroundManage>().backMarket();
    }
}
