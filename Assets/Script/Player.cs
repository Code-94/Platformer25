using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;


    private float _moveInput;
    private float _jumpInput;
    
    //private Vector2 player;
    private Rigidbody2D _prb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _prb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float HorizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(_moveInput * _speed, Time.deltaTime);
        _prb.linearVelocity = movement;
        
        _prb.AddForce(Vector2.up * _jumpForce * _jumpInput, ForceMode2D.Impulse);
        


    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log("is walking : " + ctx.ReadValue<float>());
        _moveInput = ctx.ReadValue<float>();
        
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        Debug.Log("is jumping : " + ctx.ReadValue<float>());
        _jumpInput = ctx.ReadValue<float>();
        
        
        
    }
}
