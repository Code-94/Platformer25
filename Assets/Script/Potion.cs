using UnityEngine;

public class Potion : MonoBehaviour
{

    [SerializeField] private float _heal;
    public PlayerHP _pHealth;
    
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
            _pHealth._slider.value += _heal;
            Destroy(gameObject);
        }
    }
}
