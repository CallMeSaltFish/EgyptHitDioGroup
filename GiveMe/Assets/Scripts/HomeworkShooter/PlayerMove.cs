using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    private Transform transform;
    [HideInInspector]
    public int scores;
    public int targetScores = 30;
    private void Awake()
    {
        scores = 0;
        transform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        FollowWithMouse();
        IsPassed();
    }

    void FollowWithMouse()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.x = Mathf.Clamp(vec.x, -5.4f, 5.4f);
        vec.y = transform.position.y;
        vec.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, vec, Time.deltaTime * 2);
    }
    
    void IsPassed()
    {
        if(scores >= targetScores)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.Translate(Vector3.up * Time.deltaTime * 8);
            var anim = GameObject.Find("Canvas/Shade").GetComponent<Animator>();
            anim.Play("Shade");
            StartCoroutine(LoadScene(anim));
            //Debug.Log("过关面板");
        }
    }

    IEnumerator LoadScene(Animator anim)
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        GameObject.Find("youth").GetComponent<Youth>().GameWin();
        Debug.Log("加载下一个场景");
        Destroy(GameObject.Find("homeWorkShooter(Clone)"));
        GameObject.FindWithTag("AudioSource").GetComponent<AudioSource>().Play();
    }

}
