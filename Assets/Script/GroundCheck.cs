using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float _distanceToCheck;
    public bool _isGrounded;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _distanceToCheck))
        {
            _isGrounded = true;
        }
        else
        {
            {
                _isGrounded = false;
            }
        }
    }

    // public void OnCollisionEnter2D(Collision2D collision)
    // {
    //     
    // }
}
