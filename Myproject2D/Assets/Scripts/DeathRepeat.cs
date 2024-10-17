using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRepeat : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    private bool isGameOver = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (isGameOver == true) {
            if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Batuts batuts = collision.GetComponent<Batuts>();

        if (batuts != null)
        {
            Destroy(batuts.gameObject);
        }
        else if (collision.tag == "Player")
        {
            isGameOver = true;
            levelManager.GameOver();
        }
    }   
}

