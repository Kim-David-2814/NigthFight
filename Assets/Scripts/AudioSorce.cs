using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSorce : MonoBehaviour
{
    private AudioSource _audio; //звук
    public AudioClip _click; //звук при клике

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void OnClickSounfButton()
    {
        _audio.PlayOneShot(_click);
    }
}
