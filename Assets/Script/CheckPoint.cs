using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject _player;
    
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
        if (other.CompareTag("Joueur"))
        {
            _player.transform.position = other.transform.position;
        }
    }
}
