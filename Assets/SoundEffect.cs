using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    //AUDIO    
    public AudioClip sound2;
    public AudioClip sound1;

    public void PlayASound2(){
        AudioManager.instance.PlayClipAt(sound2, transform.position);
    }

    public void PlayASound1()
    {
        AudioManager.instance.PlayClipAt(sound1, transform.position);
    }
}
