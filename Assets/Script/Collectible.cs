using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{

    //public float _coinCount;
    public PlayerMove _Cplayer;
    public TextMeshProUGUI _coinText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _coinText.text = ": " + _Cplayer._coinCount.ToString();
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Joueur"))
    //     {
    //         _coinCount += 1;
    //         Destroy(gameObject);
    //         
    //     }
    // }
}
