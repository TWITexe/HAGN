using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseToy : MonoBehaviour
{
    private Toy toy = Toy.Muffin;
    public enum Toy
    {
        Muffin,
        Holly,
        Paws,
        Nessie
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void ChoseMuffin()
    {
        Toy toy = Toy.Muffin;
    }
    public void ChoseHolly()
    {
        Toy toy = Toy.Holly;
    }
    public void ChosePaws()
    {
        Toy toy = Toy.Paws;
    }
    public void ChoseNessie()
    {
        Toy toy = Toy.Nessie;
    }
    public void PutToBed()
    {
        SceneManager.LoadScene(2);
    }
}
