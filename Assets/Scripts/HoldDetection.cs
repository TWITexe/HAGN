using UnityEngine;

public class HoldDetection : MonoBehaviour
{
    private bool isHolding = false; // Флаг, показывающий, удерживается ли объект
    [SerializeField] private float holdTimeThreshold = 1.0f; // Время удержания в секундах
    private float holdTimer = 0f; // Таймер для отслеживания времени удержания

    void Update()
    {
        DetectHold();
    }

    void DetectHold()
    {
        // Проверяем количество касаний
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Проверяем, началось ли удержание или продолжается ли оно
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // Проверяем, попали ли мы по объекту
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    if (!isHolding)
                    {
                        isHolding = true;
                        holdTimer = 0f; // Сбрасываем таймер удержания
                    }

                    holdTimer += Time.deltaTime; // Увеличиваем таймер удержания

                    // Проверяем, достигнут ли порог времени удержания
                    if (holdTimer >= holdTimeThreshold)
                    {
                        Destroy(this.gameObject);
                        ResetHold(); // Сбрасываем состояние удержания после выполнения действия
                    }
                }
                else
                {
                    ResetHold(); // Сбрасываем состояние удержания, если касание не попадает по объекту
                }
            }

            // Если палец убран с экрана или двигается, но не попадает по объекту
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                ResetHold(); // Сбрасываем состояние удержания
            }
        }
        else
        {
            ResetHold(); // Сбрасываем состояние удержания, если нет касаний
        }
    }

    void ResetHold()
    {
        isHolding = false;
        holdTimer = 0f;
    }
}
