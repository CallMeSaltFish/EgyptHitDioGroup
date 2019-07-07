using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Transform transform;
    private Rigidbody2D rigidbody;
    private Animator anim;
    private SpriteRenderer sr;

    private float time;
    [SerializeField]
    private float speed;
    private const float limitTime = 1.15f;

    private int hp;
    private GameObject[] hpSprites;
    private void Awake()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hpSprites = GameObject.FindGameObjectsWithTag("HpSprite");
        sr = GetComponent<SpriteRenderer>();
        hp = 2;
        UpdateHpSprite(hp);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);   
        Jump();
        StartFollow();
    }

    void Jump()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && time > limitTime)
        {
            
            rigidbody.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
            anim.SetBool("IsGrounded", false);
            time = 0f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            rigidbody.AddForce(Vector2.down * 9, ForceMode2D.Impulse);
        }
    }
    void StartFollow()
    {
        var temp = Camera.main.GetComponent<FollowWithPlayer>();
        if(Mathf.Abs(transform.position.x) <= 3 && !temp.isActiveAndEnabled)
        {
            temp.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("BackGround"))
        {
            anim.SetBool("IsGrounded", true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Banana":
                speed *= 2;
                StartCoroutine(RecoverSpeed());
                break;
            case "Barrier":
                Damage(1);
                break;
            case "Meow":
                Damage(2);
                break;
            case "Trap":
                Damage(2);
                break;
        }
        collision.gameObject.SetActive(false);
        if(collision.name == "Door")
        {
            this.enabled = false;
            GetComponent<Animator>().enabled = false;
            var anim = GameObject.Find("Canvas/Panel").GetComponent<Animator>();
            anim.Play("Shade");
            StartCoroutine(LoadScene(anim));
        }
    }
    

    IEnumerator RecoverSpeed()
    {
        yield return new WaitForSeconds(0.4f);
        speed /= 2;
    }
    IEnumerator LoadScene(Animator anim)
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        //加载下一个场景
        Debug.Log("加载下一个场景");
    }


    void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            Death();
        }
        UpdateHpSprite(hp);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color color = Color.white;
        for(float i = 1; i >= 0; i -= 0.05f)
        {
            color.g = i;
            color.b = i;
            sr.color = color;
            yield return 0;
        }
        for(float j = 0; j <= 1.01f; j += 0.05f)
        {
            color.g = j;
            color.b = j;
            sr.color = color;
            yield return 0;
        }
    }

    void UpdateHpSprite(int hp)
    {
        //if(hp < 0)
        //{
        //    hpSprites[0].SetActive(false);
        //    hpSprites[1].SetActive(false);
        //    hpSprites[2].SetActive(true);
        //    return;
        //}
        for(int i = 0;i < 3; i++)
        {
            if(i == 2 - hp)
            {
                hpSprites[i].SetActive(true);
            }
            else
            {
                hpSprites[i].SetActive(false);
            }
        }
    }

    void Death()
    {
        GetComponent<Animator>().enabled = false;
        this.enabled = false;
        SceneManager.LoadScene("Running");
    }
}
