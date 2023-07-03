using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOff : MonoBehaviour
{

    public void Off()
    {
        AudioSource audio = GetComponent<AudioSource>(); ;
        audio.enabled = !audio.enabled;
    }

}
