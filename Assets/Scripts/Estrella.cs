using UnityEngine;
using UnityEngine.SceneManagement;

public class Estrella : MonoBehaviour
{
    private Animator _animatorStar;

    void Awake()
    {
        _animatorStar = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _animatorStar.SetBool("IsWin", true);
    
            SceneManager.LoadScene("victoria");
        }
    }
}
