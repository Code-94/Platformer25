using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Detector : MonoBehaviour
{

    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _castDistance;
    public bool _isTouched = false;
    [SerializeField] private LayerMask _wallLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var detector = Physics2D.Raycast(transform.position, _direction, _castDistance, _wallLayer);
        
        _isTouched = detector.collider != null;
    }

    private void OnDrawGizmos()
    {
        if (!_isTouched)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, _direction.normalized * _castDistance);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, _direction.normalized * _castDistance);
        }
    }
}
