using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip[] bgms;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject[] temp = GameObject.FindGameObjectsWithTag("AudioSource");
        if(temp.Length > 1)
        {
            Destroy(temp[1]);
        }
        audioSource = GetComponent<AudioSource>();
        bgms = Resources.LoadAll<AudioClip>("Audios");
    }
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "menu")
        {
            ChangeBgm("MainMenu");
        }
        if(SceneManager.GetActiveScene().name == "Start")
        {
            ChangeBgm("Common");
        }
    }

    void ChangeBgm(string name)
    {
        if(audioSource.clip != null && audioSource.clip.name == name)
        {
            return;
        }
        foreach(AudioClip bgm in bgms)
        {
            if(bgm.name == name)
            {
                audioSource.clip = bgm;
                audioSource.Play();
                StartCoroutine(VolumeIncrease());
            }
        }
    }

    IEnumerator VolumeIncrease()
    {
        for(float i = 0.4f; i<= 1.01f; i += 0.01f)
        {
            audioSource.volume = i;
            yield return 0;
        }
    }
}
