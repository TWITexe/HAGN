using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenFadeManager : MonoBehaviour
{
    // Время плавного перехода в секундах
    [SerializeField] private float fadeDurationIn = 1.0f;
    [SerializeField] private float fadeDurationOut = 1.0f;
    private bool isFadeOut = false;
    private void Awake()
    {
        // Начнем с затемненного экрана
        StartCoroutine(FadeIn());
    }

    public void FadeOutToScene(int sceneNumber)
    {
        if (isFadeOut == false)
            StartCoroutine(FadeOut(sceneNumber));
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color =  gameObject.GetComponent<Image>().color;
        while (elapsedTime < fadeDurationIn)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDurationIn);
            gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0f);
    }

    private IEnumerator FadeOut(int sceneNumber)
    {
        float elapsedTime = 0f;
        Color color =  gameObject.GetComponent<Image>().color;
        while (elapsedTime < fadeDurationOut)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDurationOut);
            gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1f);

        // Загрузка новой сцены
        SceneManager.LoadScene(sceneNumber);
    }
}