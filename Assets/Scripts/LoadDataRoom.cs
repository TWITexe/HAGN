using UnityEngine;
using UnityEngine.UI;

public class LoadDataRoom : MonoBehaviour
{
    // Данные для изменения спрайтов комнаты относительно выбранного персонажа
    [SerializeField] private Image background;
    [SerializeField] private Sprite muffinRoom;
    [SerializeField] private Sprite hollyRoom;
    [SerializeField] private Sprite pawsRoom;
    [SerializeField] private Sprite tussyRoom;
    void Awake()
    {
        switch ((ChooseToy.Toy)PlayerPrefs.GetInt("SelectedToy"))
        {
            case ChooseToy.Toy.Muffin:
                background.sprite = muffinRoom;
                break;
            case ChooseToy.Toy.Holly:
                background.sprite = hollyRoom;
                break;
            case ChooseToy.Toy.Paws:
                background.sprite = pawsRoom;
                break;
            case ChooseToy.Toy.Tussy:
                background.sprite = tussyRoom;
                break;
        }
    }

    void Start()
    {
        
    }

}
