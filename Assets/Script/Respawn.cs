using System;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject _player;
    public GameObject _respawnPoint;
    
    [SerializeField] private PlayerHP _playerHP;
    
    [SerializeField] private float _OffLimmitDamage;
    
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
        if (other.gameObject.CompareTag("Joueur"))
        {
            _playerHP._slider.value -= _OffLimmitDamage; 
            _player.transform.position = _respawnPoint.transform.position;
        }
    }
}
