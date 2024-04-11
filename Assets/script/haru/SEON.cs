using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEON : MonoBehaviour
{
    public AudioSource SEOnShotAudioSource;
    public AudioClip SEclipAudio;
    public void OnClickButton()
    {
        SEOnShotAudioSource.PlayOneShot(SEclipAudio);
    }
}
