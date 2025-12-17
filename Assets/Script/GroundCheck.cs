using UnityEngine;

public class Ground : MonoBehaviour
{
    
    
    private bool isGrounded = false;

    private float offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = transform.position * Vector2.down * offset;
        Vector2 size = new Vector2(transform.lossyScale.x, transform.lossyScale.y);

        isGrounded = Physics2D.OverlapBox(point, size, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
