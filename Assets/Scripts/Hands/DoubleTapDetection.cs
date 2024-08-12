using UnityEngine;
using DG.Tweening;

public class DoubleTapDetection : MonoBehaviour
{
    [SerializeField] private float lastTapTime = 0f; // Время последнего нажатия
    [SerializeField] private float doubleTapThreshold = 0.3f; // Время между нажатиями для определения двойного нажатия
    [SerializeField] private float moveDuration = 1f; // Длительность анимации движения назад
    [SerializeField] private int tapCount = 0; // Количество нажатий
    private Vector2 movementDirection; // Направление движения объекта

    void Start()
    {
        // Предположим, что объект двигается к точке (0,0), как в предыдущих примерах
        Vector2 startPoint = transform.position;
        Vector2 target = new Vector2(0, 0); // Цель, к которой движется объект
        movementDirection = (target - startPoint).normalized; // Направление движения объекта
    }

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
                        // Останавливаем все текущие анимации этого объекта
                        transform.DOKill();

                        // Вычисляем конечную точку движения объекта в обратном направлении
                        Vector2 moveDirection = -movementDirection * 3f; // Увеличьте множитель для более длинного движения
                        Vector2 newTargetPosition = (Vector2)transform.position + moveDirection;

                        // Анимация движения объекта
                        transform.DOMove(newTargetPosition, moveDuration).SetEase(Ease.OutQuad);
                        tapCount = 0; // Сбрасываем счетчик после двойного нажатия
                        Destroy(this.gameObject, 1.5f);
                        Coins.Instance.AddLvlCoins(1);
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
