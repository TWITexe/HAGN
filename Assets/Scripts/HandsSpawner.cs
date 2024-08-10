using System.Collections;
using UnityEngine;
using DG.Tweening;

public class HandsSpawner : MonoBehaviour
{
    [SerializeField] Transform bedObject;
    [SerializeField] GameObject handPrefab;
    [SerializeField] int timeToSpawn;
    [SerializeField] private int speed;
    GameObject hand;
    [SerializeField] int step = 2; // ��� ��� ����������� ���� � �������.
    float posX = 0;
    float posY = 0;
    int randomSide = 0; // ( �� 1 �� 4 )

    private void Start()
    {
        StartCoroutine(SpawnHead());
    }

    void Update()
    {
        if ( hand == null && transform.position != bedObject.transform.position)
        {
           hand.transform.position = Vector3.MoveTowards(transform.position, bedObject.position, step);
        }
    }

    IEnumerator SpawnHead()
    {
        yield return new WaitForSeconds(timeToSpawn);
        ChooseSpawnPosition();
        hand = Instantiate(handPrefab, new Vector2(posX, posY),transform.rotation);
        LookAtBed(hand);
        hand.transform.DOMove(bedObject.transform.position, speed);
        StartCoroutine(SpawnHead());

    }
    void ChooseSpawnPosition()
    {
        randomSide = Random.Range(1, 5);
        switch (randomSide)
        {
            case 1:
                posX = Random.Range(-3, 3);
                posY = 5.5f;
                break;
            case 2:
                posX = -3;
                posY = Random.Range(-5, 5);
                break;
            case 3:
                posX = 3;
                posY = Random.Range(-5, 5);
                break;
            case 4:
                posX = Random.Range(-3, 3);
                posY = -5.5f;
                break;
        }
    }

    void LookAtBed(GameObject _hand) // ������� ���� � ������� �������
    {
        float dx = bedObject.transform.position.x - _hand.transform.position.x;
        float dy = bedObject.transform.position.y - _hand.transform.position.y;
        float a = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Quaternion newRotationHand = Quaternion.Euler(0, 0, a);
        _hand.transform.rotation = newRotationHand;
    }
}
