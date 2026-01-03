using UnityEngine;

public class MovingPlateforms : MonoBehaviour
{
    [SerializeField] private float _platformeForce;

    private Rigidbody2D _pltrb;
    private bool isArrived = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pltrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isArrived)
        {
            _pltrb.AddForce(Vector2.right * _platformeForce, ForceMode2D.Impulse);
        }
        else
        {
            
            _pltrb.AddForce(Vector2.left * _platformeForce, ForceMode2D.Impulse);
        }
        
    }
    
    
}
