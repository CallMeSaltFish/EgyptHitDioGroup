using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool _instance;
    private GameObject[] bullets;
    public int pooledAmount = 12;
    public bool lockPoolSize = false;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int currentIndex = 0;
    //生成子弹对象池，每种三颗
    private void Awake()
    {
        _instance = this;
        bullets = Resources.LoadAll<GameObject>("Shooter/Bullets");
        for(int i = 0; i < pooledAmount; i++)
        {
            var temp = Instantiate(bullets[i % 4]);
            temp.name = bullets[i % 4].name;
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }
    }
    //获取对象
    public GameObject GetPooledGameObject(string neededBullet)
    {
        for(int i = 0; i < pooledObjects.Count; ++i)
        {
            int temI = (currentIndex + i) % pooledObjects.Count;
            if(!pooledObjects[temI].activeInHierarchy && pooledObjects[temI].name == neededBullet)
            {
                currentIndex = (temI + 1) % pooledObjects.Count;
                return pooledObjects[temI];
            }
        }

        if(!lockPoolSize)
        {
            foreach(GameObject bullet in bullets)
            {
                if(bullet.name == neededBullet)
                {
                    var temp = Instantiate(bullet);
                    temp.name = bullet.name;
                    pooledObjects.Add(temp);
                    return temp;
                }
            }
        }

        return null;
    }
}
