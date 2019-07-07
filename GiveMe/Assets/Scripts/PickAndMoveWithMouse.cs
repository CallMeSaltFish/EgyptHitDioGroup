using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickAndMoveWithMouse : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit info, Mathf.Infinity))
        {
            Debug.Log(info.transform.tag);
        }
        else
        {
            rect.anchoredPosition = new Vector2(150, 150);
        }
    }

}
