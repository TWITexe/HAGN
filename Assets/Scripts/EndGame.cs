using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private SaveDataJSON saveDataJson;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DoubleTapDetection>() != null ||
            other.gameObject.GetComponent<HoldDetection>() != null ||
            other.gameObject.GetComponent<SwipeDetection>() != null)
        {
            Debug.Log("Game Over");
            saveDataJson.SaveData();
        }
    }  
}
