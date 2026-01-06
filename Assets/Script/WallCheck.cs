using System;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    
    [SerializeField]private float _castDistance;
    
    [SerializeField]private LayerMask _wallLayer;
    
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public bool IsWalled()
    {
        if (Physics2D.Raycast(transform.position, transform.right, _castDistance, _wallLayer))
        {
            Debug.Log("is walled");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.right * _castDistance);
    }
}
