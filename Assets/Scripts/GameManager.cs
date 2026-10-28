using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float contadorMonedas = 0;
    public Text _monedas;
    public GameObject _contador;



    public void AddCoin()
    {
        contadorMonedas += 1;
        _monedas.text = contadorMonedas.ToString();
    }
}
