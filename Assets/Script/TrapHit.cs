using UnityEngine;

public class TrapHit : MonoBehaviour
{
    
    public PlayerHP _playerHP;

    public float _trapDamage;
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
            _playerHP._slider.value -= _trapDamage;
        }
    }
}
