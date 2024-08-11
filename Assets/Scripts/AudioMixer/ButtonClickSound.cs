using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public void SoundForButton()
    {
        SoundAndMusicManager.PlaySound(SoundAndMusicManager.GetClips()[0]);
    }
    public void OffSound(int soundNum)
    {
        SoundAndMusicManager.StopMusic(SoundAndMusicManager.GetClips()[soundNum]);
    }

    public void PlayMusic(int musicNumber)
    {
        SoundAndMusicManager.PlayMusic(SoundAndMusicManager.GetClips()[musicNumber]);
    }
}
