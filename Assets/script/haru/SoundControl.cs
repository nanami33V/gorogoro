using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource m_MyAudioSource;
    public float vol;
    [SerializeField]
    private AudioClip[] clips;

    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.clip = clips[0];
        m_MyAudioSource.Play();
    }

    private void Update()
    {
        if(!m_MyAudioSource.isPlaying&&m_MyAudioSource.time==0)
        {
            Debug.Log("aa");
            m_MyAudioSource.volume = vol;
            m_MyAudioSource.clip = clips[1];
            m_MyAudioSource.Play();
        }
    }

}
