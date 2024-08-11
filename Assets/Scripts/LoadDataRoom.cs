using UnityEngine;
using UnityEngine.UI;

public class LoadDataRoom : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Sprite muffinRoom;
    [SerializeField] private Sprite hollyRoom;
    [SerializeField] private Sprite pawsRoom;
    [SerializeField] private Sprite tussyRoom;
    void Awake()
    {
        Debug.Log("LoadDataRoom");
        Debug.Log("Selected Toy: " + PlayerPrefs.GetInt("SelectedToy"));
        
        switch ((ChooseToy.Toy)PlayerPrefs.GetInt("SelectedToy"))
        {
            case ChooseToy.Toy.Muffin:
                background.sprite = muffinRoom;
                Debug.Log("MuffinRoom");
                break;
            case ChooseToy.Toy.Holly:
                background.sprite = hollyRoom;
                Debug.Log("HollyRoom");
                break;
            case ChooseToy.Toy.Paws:
                background.sprite = pawsRoom;
                Debug.Log("PawsRoom");
                break;
            case ChooseToy.Toy.Tussy:
                background.sprite = tussyRoom;
                Debug.Log("TussyRoom");
                break;
        }
    }

}
