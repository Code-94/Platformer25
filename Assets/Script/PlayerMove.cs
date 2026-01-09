using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _wallJumpX;
    [SerializeField] private float _wallJumpY;
    
    [SerializeField] private Detector _right;
    [SerializeField] private Detector _left;
    [SerializeField] private Vector2 _boxSize;
    
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _groundLayer;
    
    [SerializeField] private float _gravityA;
    [SerializeField] private float _fallSpeed;
    
    [SerializeField] private float _dashSpeed;

    // [SerializeField] private Transform _spawnPoint;
    // [SerializeField] private GameObject _fireBall;
    
    

    
    
    
    //[SerializeField] private float _dashForce;
    
    private float _moveInput;
    private bool _jumpInput;

    private bool _dashInput;
    // public bool _shootInput;
    
    private float _coyoteTime;
    private float _coyoteCounter;
    private SpriteRenderer _sprite;
    public Animator _animator;
    private bool _LeftWallSliding =  false;
    private bool _RightWallSliding = false;
    private bool _rigthShot;
    private bool _leftShot;
    private Rigidbody2D _prb;
    
    
    
    
    

    
    

    public float _coinCount;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _prb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        // _fireBall = GetComponent<GameObject>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(_moveInput * _speed, Time.fixedDeltaTime);
        _prb.linearVelocityX = movement.x;

        

        
        // if (_shootInput ==  true)
        // {
        //     // Instantiate(_fireBall, _spawnPoint.position, _spawnPoint.rotation);
        //     
        //     _animator.SetBool("IsShooting", true);
        // }
        // else
        // {
        //     _animator.SetBool("IsShooting", false);
        // }
        
        
        
        if (_prb.linearVelocityX > 0)
        {
            _animator.SetBool("IsRunning", true);
        }
        else if (_prb.linearVelocityX < 0)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
        
            
         if (IsGrounded())
         {
             //_prb.AddForce(_jumpForce *_jumpInput * Vector2.up, ForceMode2D.Impulse);
             
             // Vector2 jump = new Vector2( Time.fixedDeltaTime, _jumpInput * _jumpForce);
             // _prb.linearVelocityY = jump.y;
             
              if (_jumpInput == true)
              {
                  Vector2 Jump = new Vector2(Time.fixedDeltaTime,_jumpForce);
                  _prb.linearVelocity = Jump;
                  
                  _animator.SetBool("IsJumping", true);
              }
              else if (_jumpInput == false)
              {
                  _animator.SetBool("IsJumping", false);
              }
             _animator.SetBool("IsFalling", false);
             
         }
         else if(!IsGrounded())
         {
             _prb.gravityScale = _gravityA;
             _animator.SetBool("IsFalling", true);
         }

         if (_left._isTouched)
         {
             Vector2 Fall = new Vector2(Time.fixedDeltaTime, -_fallSpeed);
             _prb.linearVelocityY = Fall.y;
             _LeftWallSliding = true;
         }
         

         if (_right._isTouched)
         {
             Vector2 Fall = new Vector2(Time.fixedDeltaTime, -_fallSpeed);
             _prb.linearVelocityY = Fall.y;
             _RightWallSliding = true;
         }
         
         
         


         if (_LeftWallSliding == true)
         {
             
             
             //_prb.AddForce((_jumpInput * _wallForce) * new Vector2(1.25f,1.25f),  ForceMode2D.Impulse);
             if (_jumpInput == true)
             {
                 
                 Vector2 WJump = new Vector2(_wallJumpX, _wallJumpY);
                 _prb.linearVelocity =  WJump;
             }
            
             

         }

         if (_RightWallSliding == true)
         {
             
             //_prb.AddForce((_jumpInput * _wallForce) * new Vector2(-1.25f,1.25f),  ForceMode2D.Impulse);
             if (_jumpInput == true)
             {
                 Vector2 WJump = new Vector2(-_wallJumpX, _wallJumpY);
                 _prb.linearVelocity =  WJump;
                 
             }
         }
         _LeftWallSliding = false;
         _RightWallSliding = false;

         if (_dashInput == true && movement.x > 0)
         {
             Vector2 Rdash = new Vector2(_dashSpeed,Time.fixedDeltaTime);
             _prb.linearVelocityX =  Rdash.x;
             _animator.SetBool("IsDashing", true);
         } else if (_dashInput == false)
         {
             _animator.SetBool("IsDashing", false);
         }

         if (_dashInput == true && movement.x < 0)
         {
             Vector2 Rdash = new Vector2(-_dashSpeed,Time.fixedDeltaTime);
             _prb.linearVelocityX =  Rdash.x;
             _animator.SetBool("IsDashing", true);
         }else if (_dashInput == false)
         {
             _animator.SetBool("IsDashing", false);
         }
         
         

         
         
         // if (_left._isTouched)
         // {
         //     _prb.AddForce(_wallForce * _jumpInput * new Vector2(1,0.5f), ForceMode2D.Impulse );
         //     _prb.gravityScale = _gravity;
         // }
         //
         // if(_right._isTouched)
         // {
         //     _prb.AddForce(_wallForce * _jumpInput * new Vector2(-1,0.5f), ForceMode2D.Impulse );
         //     _prb.gravityScale = _gravity;
         // }
         //
         // if (_left._isTouched || _right._isTouched)
         // {
         //     _prb.gravityScale = _gravity;
         // }
         // else
         // {
         //     _prb.gravityScale = 1;
         // }
         
         
         
         


        if (movement.x < 0)
        {
            _sprite.flipX = true;

        }
        else if(movement.x > 0)
        {
            _sprite.flipX = false;
        } 
        
        // if (_isFacingRight && movement.x < 0)
        // {
        //     Flip();
        //     _animator.SetBool("IsRunning", true);
        // } else if (!_isFacingRight && movement.x > 0)
        // {
        //     Flip();
        // }
        
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
         if (ctx.performed)
         {
             _jumpInput = true;
             
             Debug.Log("is jumping : " + ctx.performed);
         }

         if (ctx.canceled)
         {
             _jumpInput = false;
             
         }
        // Debug.Log("is jumping : " + ctx.ReadValue<float>());
        // _jumpInput = ctx.ReadValue<float>();
     }

     public void OnDash(InputAction.CallbackContext ctx)
     {
         if (ctx.performed)
         {
             _dashInput = true;
             Debug.Log("is dashing : " + ctx.performed); 
         }

         if (ctx.canceled)
         {
             _dashInput = false;
         }
         
     }

     //  public void IsShooting(InputAction.CallbackContext ctx)
     //  {
     //      if (ctx.performed)
     //      {
     //          _shootInput = true;
     //          Debug.Log("Shot");
     //      }
     //
     //      if (ctx.canceled)
     //      {
     //          _shootInput = false;
     //     }
     // }

     
     private bool IsGrounded()
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

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("Coin"))
         {
             Destroy(other.gameObject);
             _coinCount++;
         }
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
