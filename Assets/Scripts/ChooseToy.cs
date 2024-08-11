using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseToy : MonoBehaviour
{
    public static ChooseToy Instance { get; private set; }
    private Toy toy;
    public enum Toy
    {
        Muffin,
        Holly,
        Paws,
        Tussy
    }

    /*void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    
    public Toy GetToy()
    {
        return toy;
    }
    public void ChoseMuffin()
    {
        toy = Toy.Muffin;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Muffin);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
    }
    public void ChoseHolly()
    {
        toy = Toy.Holly;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Holly);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
    }
    public void ChosePaws()
    {
        toy = Toy.Paws;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Paws);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
        
    }
    public void ChoseTussy()
    {
        toy = Toy.Tussy;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Tussy);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
    }
}
