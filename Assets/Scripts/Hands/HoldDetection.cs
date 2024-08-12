using System.Collections;
using UnityEngine;
using DG.Tweening;

public class HoldDetection : MonoBehaviour
{
    private bool isHolding = false; // Флаг, показывающий, удерживается ли объект
    [SerializeField] private float holdTimeThreshold = 1.0f; // Время удержания в секундах
    [SerializeField] private float moveDuration = 1f; // Длительность анимации движения назад
    private float holdTimer = 0f; // Таймер для отслеживания времени удержания
    private Vector2 movementDirection; // Направление движения объекта
    private bool isCaughtMonster = false;

    void Start()
    {
        Vector2 startPoint = transform.position;
        Vector2 target = new Vector2(0, 0); // Цель, к которой движется объект
        movementDirection = (target - startPoint).normalized; // Направление движения объекта
    }

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
                        // Останавливаем все текущие анимации этого объекта
                        transform.DOKill();
                        // Вычисляем конечную точку движения объекта в обратном направлении
                        Vector2 moveDirection = -movementDirection * 3f;
                        Vector2 newTargetPosition = (Vector2)transform.position + moveDirection;
                        // Анимация движения объекта
                        transform.DOMove(newTargetPosition, moveDuration).SetEase(Ease.OutQuad);
                        Destroy(this.gameObject, 1.5f);
                        if (isCaughtMonster == false)
                        {
                            Coins.Instance.AddLvlCoins(1);
                            isCaughtMonster = true;
                        }
                            
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
