using UnityEngine;

public class Coins : MonoBehaviour
{
    // Синглтон экземпляр
    public static Coins Instance { get; private set; }

    // Переменная для хранения количества валюты
    [SerializeField] private int coinAmount;

    private void Awake()
    {
        // Проверяем, существует ли уже экземпляр
        if (Instance == null)
        {
            // Если нет, устанавливаем текущий экземпляр
            Instance = this;
            // Не уничтожаем объект при переходе между сценами
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Если уже существует, уничтожаем текущий объект
            Destroy(gameObject);
        }
        
    }

    // Метод для получения количества валюты
    public int GetCoinsInfo()
    {
        return coinAmount;
    }

    // Метод для добавления валюты
    public void AddCoins(int amount)
    {
        if (amount > 0)
            coinAmount += amount;
    }

    // Метод для списания валюты
    public bool SpendCoins(int amount)
    {
        if (coinAmount >= amount)
        {
            coinAmount -= amount;
            return true;
        }
        return false;
    }
    
}