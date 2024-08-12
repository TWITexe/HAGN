using System.Collections;
using UnityEngine;
using DG.Tweening;

public class HandsSpawner : MonoBehaviour
{
    // Трансформ кровати
    [SerializeField] private Transform bedObject;
    // Время между спавнами рук
    [SerializeField] int timeToSpawn;
    // Скорость перемещения рук к кровати после спавна
    [SerializeField] private float speed;
    // Массив различных видов рук
    [SerializeField] private GameObject[] hands;
    // Заспавнившаяся рука
    private GameObject hand;
    // Данные для определения поворота рук
    float posX = 0;
    float posY = 0;
    // Случайная сторона для спавна руки ( случайный выбор из 4 сторон )
    int randomSide = 0; // ( от 1 до 4 )

    private void Start()
    {
        StartCoroutine(SpawnHead());
    }

    IEnumerator SpawnHead()
    {
        yield return new WaitForSeconds(timeToSpawn);
        ChooseSpawnPosition();
        hand = Instantiate(hands[Random.Range(0, hands.Length)], new Vector2(posX, posY),transform.rotation);
        LookAtBed(hand);
        hand.transform.DOMove(bedObject.transform.position, speed);
        StartCoroutine(SpawnHead());

    }
    private void ChooseSpawnPosition()
    {
        randomSide = Random.Range(1, 5);
       switch (randomSide)
       {
           case 1:
               posX = Random.Range(-4, 4);
               posY = 6.5f;
               break;
           case 2:
               posX = -4;
               posY = Random.Range(-6, 6);
                break;
            case 3:
                posX = 4;
                posY = Random.Range(-6, 6);
                break;
            case 4:
                posX = Random.Range(-4, 4);
                posY = -6.5f;
                break;
        }
       IncreasingDifficulty();
    }

    void LookAtBed(GameObject _hand) // Поворот руки в сторону кровати
    {
        float dx = bedObject.transform.position.x - _hand.transform.position.x;
        float dy = bedObject.transform.position.y - _hand.transform.position.y;
        float a = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Quaternion newRotationHand = Quaternion.Euler(0, 0, a);
        _hand.transform.rotation = newRotationHand;
    }

    void IncreasingDifficulty()
    {
        if (speed > 5 )
            speed -= 0.035f;
    }
}
