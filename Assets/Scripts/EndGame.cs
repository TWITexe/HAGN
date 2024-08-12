using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private SaveDataJSON saveDataJson;
    [SerializeField] private ScreenFadeManager fade; // Плавный переход между сценами
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DoubleTapDetection>() != null ||
            other.gameObject.GetComponent<HoldDetection>() != null ||
            other.gameObject.GetComponent<SwipeDetection>() != null)
        {
            SoundAndMusicManager.PlayMusic(SoundAndMusicManager.GetClips()[3]);
            Coins.Instance.AddCoins(Coins.Instance.GetCoinsLvlInfo()); // Прибавляем коины уровня в игру
            Coins.Instance.SpendLvlCoins(Coins.Instance.GetCoinsLvlInfo()); // Обнуляем коины на уровне
            saveDataJson.SaveData();
            Handheld.Vibrate();
            fade.FadeOutToScene(1);

        }
    }

}
