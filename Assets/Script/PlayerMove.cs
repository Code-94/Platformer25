using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    //[SerializeField] private float _dashForce;
    
    private float _moveInput;
    private float _jumpInput;
    private bool _isGrounded = false;
    
    
    private Rigidbody2D _prb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _prb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(_moveInput * _speed, Time.fixedDeltaTime);
        _prb.linearVelocity = movement;

        if (_isGrounded == true)
        {
            _prb.AddForce(Vector2.up * _jumpInput * _jumpForce, ForceMode2D.Impulse);
        }

    }

    public void OnWalk(InputAction.CallbackContext ctx)
    {
        Debug.Log("is walking : " + ctx.ReadValue<float>());
        _moveInput = ctx.ReadValue<float>();
        
    }

     public void OnJump(InputAction.CallbackContext ctx)
     {
        
        Debug.Log("is jumping : " + ctx.ReadValue<float>());
         _jumpInput = ctx.ReadValue<float>();
        
     }

    // public void OnDash(InputAction.CallbackContext ctx)
    // {
    //     Debug.Log("is dashing : " + ctx.ReadValue<float>());
    //     _dashInput = ctx.ReadValue<float>();
    // }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("is grounded");
            _isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("air");
            _isGrounded = false;
        }
    }
}
