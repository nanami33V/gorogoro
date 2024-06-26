using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource m_MyAudioSource;
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
        //一定時間計測すると別の音源に切り替わる
        if(!m_MyAudioSource.isPlaying&&m_MyAudioSource.time==0)
        {
            m_MyAudioSource.clip = clips[1];
            m_MyAudioSource.Play();
        }
    }

}
