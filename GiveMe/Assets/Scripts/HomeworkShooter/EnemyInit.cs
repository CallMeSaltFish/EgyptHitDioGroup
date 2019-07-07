using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInit : MonoBehaviour
{
    private const float y = 10.6f;
    private float[] xPositions;
    private GameObject[] enemys;

    private float lastX;
    private GameObject lastEnemy;

    private void Awake()
    {
        xPositions = new float[4] { -4.6f, -2f, 2f, 4.6f };
        enemys = Resources.LoadAll<GameObject>("Shooter/Targets");
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InitEnemy", 1.5f, 1.5f);
    }

    Vector3 RandomLocation()
    {
        var temp = 0f;
        do
        {
            temp = xPositions[Random.Range(0, xPositions.Length)];
        } while (temp == lastX);
        lastX = temp;
        return new Vector3(temp, y, 0);
    }

    GameObject RandomEnemy()
    {
        GameObject temp = null;
        do
        {
            temp = enemys[Random.Range(0, enemys.Length)];
        } while (temp == lastEnemy);
        lastEnemy = temp;
        return temp;
    }

    void InitEnemy()
    {
        GameObject temp2 = RandomEnemy();
        GameObject temp = Instantiate(temp2, RandomLocation(), Quaternion.identity, transform);
        temp.name = temp2.name;
    }
}
