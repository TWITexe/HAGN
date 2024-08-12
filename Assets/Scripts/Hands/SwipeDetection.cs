using UnityEngine;
using DG.Tweening;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float swipeLength = 0.7f;
    [SerializeField] private float moveDuration = 1f; // Длительность анимации движения назад
    private Vector2 target = new Vector2(0, 0); // Цель, к которой движется объект
    private Vector2 movementDirection; // Направление движения объекта
    private Vector2 startPoint; // Начальная точка (позиция объекта)
    private Vector2 endPoint = Vector2.zero; // Конечная точка (x=0, y=0)
    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;
    private bool touchedObject = false; // Флаг, был ли объект затронут

    void Start()
    {
        // Вычисляю направление движения объекта
        startPoint = transform.position; // Начальная точка для свайпа
        movementDirection = (target - startPoint).normalized; // Направление движения
    }

    void Update()
    {
        DetectSwipe();
    }

    void DetectSwipe()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStartPosition = touch.position; // Начало свайпа

                // Проверяю, коснулся ли пользователь объекта
                Vector2 touchWorldPosition = Camera.main.ScreenToWorldPoint(swipeStartPosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(touchWorldPosition);

                if (hitCollider != null && hitCollider.gameObject == gameObject)
                {
                    touchedObject = true; // Игрок коснулся объекта
                }
                else
                {
                    touchedObject = false; // Игрок не попал по объекту
                }
            }

            if (touch.phase == TouchPhase.Ended && touchedObject)
            {
                swipeEndPosition = touch.position; // Конец свайпа

                // Преобразую экранные координаты в мировые координаты
                Vector2 swipeStartWorld = Camera.main.ScreenToWorldPoint(swipeStartPosition);
                Vector2 swipeEndWorld = Camera.main.ScreenToWorldPoint(swipeEndPosition);

                // Вычисляю направление свайпа в мировых координатах
                Vector2 swipeDirection = (swipeEndWorld - swipeStartWorld).normalized;

                // Вычисляю направление к конечной точке (0,0) из начальной точки
                Vector2 directionToZero = (endPoint - startPoint).normalized;

                // Проверяю, совпадает ли направление свайпа с направлением, противоположным движению объекта
                if (Vector2.Dot(swipeDirection, -directionToZero) > swipeLength) // swipeLength - пороговое значение, можно корректировать
                {
                    Coins.Instance.AddLvlCoins(1);
                    
                    // Вычисляю конечную точку движения объекта в обратном направлении
                    Vector2 moveDirection = -movementDirection * 3f; // Увеличиваю множитель для более длинного движения
                    Vector2 newTargetPosition = (Vector2)transform.position + moveDirection;

                    // Анимация движения объекта
                    transform.DOKill();
                    transform.DOMove(newTargetPosition, moveDuration).SetEase(Ease.OutQuad);
                    Destroy(this.gameObject, 1.5f);

                }
            }
        }
    }
}
