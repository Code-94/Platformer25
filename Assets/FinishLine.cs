using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]private GameManagerScript _gameManager;
    

    private bool _isDone = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Joueur") && !_isDone)
        {
            _isDone = true;
            _gameManager.GameOver();
        }
        
    }
}
