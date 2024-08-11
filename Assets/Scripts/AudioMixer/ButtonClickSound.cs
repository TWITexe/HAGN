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
        SoundAndMusicManager.StopSound(SoundAndMusicManager.GetClips()[soundNum]);
    }
}
