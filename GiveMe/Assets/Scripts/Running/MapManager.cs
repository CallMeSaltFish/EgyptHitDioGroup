using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //方案一，废旧方案

    //public class Map
    //{
    //    public GameObject map;
    //    public Vector2 position;

    //    public Map(GameObject map,Vector2 position)
    //    {
    //        this.map = map;
    //        this.position = position;
    //    }
    //}

    //private GameObject[] maps;
    //private LinkedList<Map> twoMaps = new LinkedList<Map>();
    //private Transform playerTransform;
    //private Transform thisMap;
    //private Transform lastMap;


    //private const float interval = 10.8f;
    //private const float distanceBetweenPlayerAndLastMap = 3f;

    //private void Awake()
    //{
    //    maps = Resources.LoadAll<GameObject>("RunningMap");
    //    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //InitLinkedList();
    //    //MapCycle();
    //}

    //void InitLinkedList()
    //{
    //    if (twoMaps.Count <= 0)
    //    {
    //        var mapPosition = Vector2.zero;
    //        lastMap = Instantiate(map, mapPosition, Quaternion.identity, transform).transform;
    //        twoMaps.AddFirst(new LinkedListNode<Map>(new Map(map, mapPosition)));
    //        mapPosition.x += interval;
    //        thisMap = Instantiate(map, mapPosition, Quaternion.identity, transform).transform;
    //        twoMaps.AddLast(new LinkedListNode<Map>(new Map(map, mapPosition)));
    //    }
    //}

    //void MapCycle()
    //{
    //    if(twoMaps.Count >= 2)
    //    {
    //        if(Mathf.Abs(playerTransform.position.x - twoMaps.Last.Value.position.x) 
    //            <= distanceBetweenPlayerAndLastMap)
    //        {
    //            Swap();
    //        }
    //    }
    //}

    //void Swap()
    //{
    //    var mapPosition = twoMaps.Last.Value.position;
    //    mapPosition.x += interval;
    //    lastMap.position = mapPosition;
    //    var temp1 = lastMap;
    //    lastMap = thisMap;
    //    thisMap = temp1;
    //    twoMaps.First.Value.position = mapPosition;
    //    var temp2 = twoMaps.First;
    //    twoMaps.RemoveFirst();
    //    twoMaps.AddLast(temp2);
    //}

    //方案二

    private GameObject[] maps;
    private GameObject player;
    private int lastNumber = 0;

    private void Awake()
    {
        maps = Resources.LoadAll<GameObject>("RunningMap");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private const float pieces = 10;
    private const float interval = 10.8f;
    private const float totalDistance = (pieces + 1) * interval;
    private void Start()
    {
        InitMap();
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<PlayerControl>().enabled = false;
        //Time.timeScale = 0;
    }
    private void Update()
    {
        StopCamera();
    }
    void InitMap()
    {
        var vec = Vector3.zero;
        Instantiate(maps[4], vec, Quaternion.identity, transform);
        for(int i = 0; i < pieces; i++)
        {
            vec.x += interval;
            Instantiate(maps[RandomNumber()], vec, Quaternion.identity, transform);
        }
        vec.x += interval;
        Instantiate(maps[0], vec, Quaternion.identity, transform);
    }

    int RandomNumber()
    {
        var temp = 0;
        do
        {
            temp = Random.Range(1, 4);
        } while (temp == lastNumber);
        lastNumber = temp;
        return temp;
    }

    void StopCamera()
    {
        var temp = Camera.main;
        if(Mathf.Abs(totalDistance - temp.transform.position.x) <= 0.1f)
        {
            temp.GetComponent<FollowWithPlayer>().enabled = false;
        }
    }
}
