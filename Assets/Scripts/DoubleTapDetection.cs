using UnityEngine;

public class DoubleTapDetection : MonoBehaviour
{
    [SerializeField] private float lastTapTime = 0f; // Время последнего нажатия
    [SerializeField] private float doubleTapThreshold = 0.3f; // Время между нажатиями для определения двойного нажатия
    [SerializeField] private int tapCount = 0; // Количество нажатий

    void Update()
    {
        DetectDoubleTap();
    }

    void DetectDoubleTap()
    {
        // Проверяем количество касаний
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Проверяем, что касание только что произошло
            if (touch.phase == TouchPhase.Ended)
            {
                // Проверяем, попали ли мы по объекту
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    tapCount++;

                    if (tapCount == 1)
                    {
                        lastTapTime = Time.time; // Сохраняем время первого нажатия
                    }
                    else if (tapCount == 2 && Time.time - lastTapTime < doubleTapThreshold)
                    {
                        Destroy(this.gameObject);
                        tapCount = 0; // Сбрасываем счетчик после двойного нажатия
                    }
                }

                if (Time.time - lastTapTime > doubleTapThreshold)
                {
                    tapCount = 0; // Сбрасываем счетчик, если прошло слишком много времени между нажатиями
                }
            }
        }
    }
}