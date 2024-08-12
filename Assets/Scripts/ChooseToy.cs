using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseToy : MonoBehaviour
{
    public static ChooseToy Instance { get; private set; }
    private Toy toy;
    [SerializeField] private GameObject muffin;
    [SerializeField] private GameObject holly;
    [SerializeField] private GameObject paws;
    [SerializeField] private GameObject tussy;
    [SerializeField] private Sprite[] muffinsSprites; // 0 - в коробке, 1 - без коробки, 2 - активный
    [SerializeField] private Sprite[] hollySprites; 
    [SerializeField] private Sprite[] pawsSprites;
    [SerializeField] private Sprite[] tussySprites; 
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
        ToyState(true,false,false,false);
        toy = Toy.Muffin;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Muffin);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
    }
    public void ChoseHolly()
    {
        ToyState(false,true,false,false);
        toy = Toy.Holly;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Holly);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
    }
    public void ChosePaws()
    {
        ToyState(false,false,true,false);
        toy = Toy.Paws;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Paws);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
        
    }
    public void ChoseTussy()
    {
        ToyState(false,false,false,true);
        toy = Toy.Tussy;
        PlayerPrefs.SetInt("SelectedToy", (int)Toy.Tussy);
        PlayerPrefs.Save(); // Явное сохранение данных
        Debug.Log("Selected Toy Saved: " + PlayerPrefs.GetInt("SelectedToy"));
    }

    void ToyState(bool _muffin, bool _holly, bool _paws, bool _tussy)
    {
        if (_muffin)
            muffin.GetComponent<Image>().sprite = muffinsSprites[2];
        else
            muffin.GetComponent<Image>().sprite = muffinsSprites[1];
            
        /*if (_holly)
            holly.GetComponent<Image>().sprite = hollySprites[2];
        else
            holly.GetComponent<Image>().sprite = hollySprites[1];
        
        if (_paws)
            paws.GetComponent<Image>().sprite = pawsSprites[2];
        else
            paws.GetComponent<Image>().sprite = pawsSprites[1];
        
        if (_tussy)
            tussy.GetComponent<Image>().sprite = tussySprites[2];
        else
            tussy.GetComponent<Image>().sprite = tussySprites[1];*/
    }
}
