using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float swipeLength = 0.7f;
    private Vector2 target = new Vector2(0,0); // Цель, к которой движется объект
    private Vector2 movementDirection; // Направление движения объекта
    private Vector2 startPoint; // Начальная точка (позиция объекта)
    private Vector2 endPoint = Vector2.zero; // Конечная точка (x=0, y=0)
    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;

    void Start()
    {
        // Вычисляем направление движения объекта
        startPoint = transform.position; // Начальная точка для свайпа
        movementDirection = (target - (startPoint).normalized); // Направление движения
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
            }

            if (touch.phase == TouchPhase.Ended)
            {
                swipeEndPosition = touch.position; // Конец свайпа

                // Преобразуем экранные координаты в мировые координаты
                Vector2 swipeStartWorld = Camera.main.ScreenToWorldPoint(swipeStartPosition);
                Vector2 swipeEndWorld = Camera.main.ScreenToWorldPoint(swipeEndPosition);
                
                // Вычисляем направление свайпа в мировых координатах
                Vector2 swipeDirection = (swipeEndWorld - swipeStartWorld).normalized;

                // Вычисляем направление к конечной точке (0,0) из начальной точки
                Vector2 directionToZero = (endPoint - startPoint).normalized;

                // Проверяем, совпадает ли направление свайпа с направлением, противоположным движению объекта
                if (Vector2.Dot(swipeDirection, -directionToZero) > swipeLength) //swipeLenght - пороговое значение, можно корректировать
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
