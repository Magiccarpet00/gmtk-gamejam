using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioMixerGroup soundEffectMixer;

    void Awake(){
        instance = this;
    }

    public AudioClip[] playlist;
    public AudioSource audioSource;

    void Start(){
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    void Update(){
        if(!audioSource.isPlaying){
            audioSource.Play();
        }
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;

        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }

}
