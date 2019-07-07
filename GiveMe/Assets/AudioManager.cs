using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
