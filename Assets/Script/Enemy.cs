using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    [SerializeField]private PlayerHP _playerHP;

    [SerializeField ]private float _enemyDamage;
    [SerializeField] private float _enemyspeed;
    [SerializeField]private Transform _pointA;
    [SerializeField]private Transform _pointB;

    private SpriteRenderer _sprite;

    private Vector3 _nextPosition;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _nextPosition = _pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _enemyspeed * Time.deltaTime);

        if (transform.position == _nextPosition)
        {
            _nextPosition = (_nextPosition == _pointA.position) ? _pointB.position : _pointA.position;
            
            
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Joueur"))
        {
            _playerHP._slider.value -= _enemyDamage;
        }

        if (other.gameObject.CompareTag("FireBall"))
        {
            Destroy(gameObject);
        }
    }
}
