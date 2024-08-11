using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusicManager : MonoBehaviour
{
    public AudioClip[] audioClips;
 
    public static SoundAndMusicManager instance;
 
    [SerializeField] private AudioSource gameSoundFX;
    [SerializeField] private AudioSource gameMusic;

    void Start ()
    {
        if (instance == null) instance = this;
 
        DontDestroyOnLoad(gameObject); // объект не будет уничтожатся при загрузке новой сцены
    }
    
 
    public void PlaySoundClip(AudioClip clip)
    {
        gameSoundFX.clip = clip;
        gameSoundFX.Play();
    }
    public void StopSoundClip(AudioClip clip)
    {
        gameMusic.clip = clip;
        gameMusic.Stop();
    }

    public static AudioClip[] GetClips ()
    {
        return instance.audioClips;
    }
 
 
    // это просто заглушка, чтобы в других скриптах НЕ писать AudioManager.insatance.playSound(clip);
 
    public static void PlaySound(AudioClip clip) 
    {
        instance.PlaySoundClip(clip);
    }
    public static void StopSound(AudioClip clip) 
    {
        instance.StopSoundClip(clip);
    }
}
