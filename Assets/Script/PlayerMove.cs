using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _wallForce;

    
    //[SerializeField] private float _dashForce;
    
    private float _moveInput;
    private float _jumpInput;
    
    private Animator _animator;

    public WallJump _wallJump;
    
    

    [SerializeField] private Vector2 _boxSize;
    
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _groundLayer;
    //private bool _isFacingRight = true;

    private float _jumpMaxHeight;

    
    //private bool _isGrounded = false;
    
    
    private Rigidbody2D _prb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _prb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(_moveInput * _speed, Time.fixedDeltaTime);
        _prb.linearVelocityX = movement.x;

        // _isFacingRight = !_isFacingRight;
        // transform.Rotate(0f, _moveInput, 0f);
        
        if (_prb.linearVelocityX > 0)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            {
                _animator.SetBool("IsRunning", false);
            }
        }

        if (IsGrounded())
        {
            _prb.AddForce(_jumpForce *_jumpInput * Vector2.up, ForceMode2D.Impulse);
            
             if (_jumpInput > 0)
             {
                 _animator.SetBool("IsJumping", true);
             }
             else if (_jumpInput <= 0)
             {
                 _animator.SetBool("IsJumping", false);
             }
            _animator.SetBool("IsFalling", false);
            
        }
        else if(!IsGrounded())
        {
            _animator.SetBool("IsFalling", true);
        }

        if (_wallJump.IsWalled())
        {
            _prb.AddForce(_wallForce * _jumpInput * Vector2.right, ForceMode2D.Impulse );
            Debug.Log("is Walled");
        }
        
        // if (_isGrounded == true)
        // {
        //     _prb.AddForce(Vector2.up * _jumpInput * _jumpForce, ForceMode2D.Impulse);
        // }

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

     public bool IsGrounded()
     {
         if (Physics2D.BoxCast(transform.position, _boxSize, 0, -transform.up, _castDistance, _groundLayer ))
         {
             return true;
         }
         else
         {
             return false;
         }
     }

     private void OnDrawGizmos()
     {
         Gizmos.DrawWireCube(transform.position-transform.up * _castDistance, _boxSize);
     }

     

   

     
         


     


     // public void OnDash(InputAction.CallbackContext ctx)
    // {
    //     Debug.Log("is dashing : " + ctx.ReadValue<float>());
    //     _dashInput = ctx.ReadValue<float>();
    // }

    // public void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         Debug.Log("is grounded");
    //         _isGrounded = true;
    //     }
    // }
    //
    // public void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         Debug.Log("air");
    //         _isGrounded = false;
    //     }
    // }
}
