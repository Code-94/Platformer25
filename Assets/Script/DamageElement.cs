using UnityEngine;

public class DamageElement : MonoBehaviour
{
    public float _damage;
    public PlayerHealth _playerHp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TestDam"))
        {
            _playerHp._currentHp -= _damage;
            
        }
    }
}
