using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoop : MonoBehaviour
{
    private GameObject map;
    private LinkedList<GameObject> twoMaps = new LinkedList<GameObject>();
    private Transform cameraTransform;

    private const float interval = 19.2f;
    private const float distanceBetweenCameraAndFirstMap = 19.2f;

    private void Awake()
    {
        map = Resources.Load<GameObject>("Shooter/BackGround");
        cameraTransform = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        InitLinkedList();
        MapCycle();
    }
    void InitLinkedList()
    {
        if(twoMaps.Count <= 0)
        {
            var mapPosition = Vector2.zero;
            var temp = Instantiate(map, mapPosition, Quaternion.identity, transform);
            twoMaps.AddFirst(new LinkedListNode<GameObject>(temp));
            mapPosition.y += interval;
            temp = Instantiate(map, mapPosition, Quaternion.identity, transform);
            twoMaps.AddLast(new LinkedListNode<GameObject>(temp));
        }
    }

    void MapCycle()
    {
        if(twoMaps.Count >= 2)
        {
            if (Mathf.Abs(cameraTransform.position.y - twoMaps.First.Value.transform.position.y)
                >= distanceBetweenCameraAndFirstMap)
            {
                Swap();
            }
        }
    }

    void Swap()
    {
        var firstMap = twoMaps.First;
        var firstMapPosition = firstMap.Value.transform.position;
        firstMapPosition.y += 2 * distanceBetweenCameraAndFirstMap;
        twoMaps.First.Value.transform.position = firstMapPosition;
        twoMaps.RemoveFirst();
        twoMaps.AddLast(firstMap);
    }
}
