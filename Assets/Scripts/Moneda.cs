using UnityEngine;

public class Moneda : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject _gameManagerObject;

    void Awake()
    {
        _gameManagerObject = GameObject.Find("GameManager");

        _gameManager = _gameManagerObject.GetComponent<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.CompareTag("Player"))
        {
            _gameManager.AddCoin();
            Destroy(gameObject);
        }
    }
}
