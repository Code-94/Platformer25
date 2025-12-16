using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float _speed;

    
    private Vector2 player;
    private Rigidbody2D _prb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _prb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        
        _prb.linearVelocity =  Vector2.right * HorizontalInput * _speed;
        
        
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log("is walking" + ctx.ReadValue<float>());
        _prb.linearVelocity = Vector2.right * ctx.ReadValue<float>();
        
    }
}
