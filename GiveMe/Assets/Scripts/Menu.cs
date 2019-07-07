using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void NewGameDown(){
        Animator anim = GameObject.Find("Canvas/Shade").GetComponent<Animator>();
        anim.Play("Shade");
        StartCoroutine(LoadScene(anim));
        StartCoroutine(VolumeDecrease());
    }

    public void ExitDown()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(Animator anim)
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        SceneManager.LoadScene(1);
    }
    IEnumerator VolumeDecrease()
    {
        AudioSource audio = GameObject.FindWithTag("AudioSource").GetComponent<AudioSource>();
        for(float i = 1f;i >= 0.4f; i -= 0.01f)
        {
            audio.volume = i;
            yield return 0;
        }
    }
}
