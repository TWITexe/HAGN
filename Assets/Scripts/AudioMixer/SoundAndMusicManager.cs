using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public static AudioClip[] GetClips() // Получения списка аудиоклипов
    {
        return instance.audioClips;
    }
    public void PlaySoundClip(AudioClip clip)
    {
        gameSoundFX.clip = clip;
        gameSoundFX.Play();
    }
    public void PlayMusicClip(AudioClip clip) 
    {
        gameMusic.clip = clip;
        gameMusic.Play();
    }
    public void StopMusicClip(AudioClip clip)
    {
        gameMusic.clip = clip;
        gameMusic.Stop();
    }
    
    // Далее методы для удобства, чтобы в других скриптах постоянно не писать: AudioManager.insatance.playSound(clip);
    public static void PlayMusic(AudioClip clip) // Включение музыки
    {
        instance.PlayMusicClip(clip);
    }
    public static void StopMusic(AudioClip clip)  // Выключение музыки
    {
        instance.StopMusicClip(clip);
    }
    public static void PlaySound(AudioClip clip)  // Включение звуков ( звуки выключать не надо, они короткие )
    {
        instance.PlaySoundClip(clip);
    }
}
