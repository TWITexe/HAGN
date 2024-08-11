using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerVolume : MonoBehaviour
{
    // Наш аудиомикшер
    [SerializeField] private AudioMixerGroup _mixer;
    private bool musicOff = false;
    private bool soundFXOff = false;
    // Кнопки
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    // Спрайты для отображения значений
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;
    [SerializeField] private Sprite soundFXOnSprite;
    [SerializeField] private Sprite soundFXOffSprite;

    public void ChangeMusicVolume()
    {
        if (musicOff)
        {
            _mixer.audioMixer.SetFloat("MusicVolume", -20);
            musicOff = false;
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            _mixer.audioMixer.SetFloat("MusicVolume", -80);
            musicOff = true;
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
    }

    public void ChangeSoundFXVolume()
    {
        if (soundFXOff)
        {
            _mixer.audioMixer.SetFloat("SoundFXVolume", -20);
            soundFXOff = false;
            soundButton.GetComponent<Image>().sprite = soundFXOnSprite;
        }
        else
        {
            _mixer.audioMixer.SetFloat("SoundFXVolume", -80);
            soundFXOff = true;
            soundButton.GetComponent<Image>().sprite = soundFXOffSprite;
        }
    }
}
