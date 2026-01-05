using System;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlateforms : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    [SerializeField] private float _platformSpeed;

    private Vector3 _nextPosition;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _nextPosition = _pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _platformSpeed * Time.deltaTime);

        if (transform.position == _nextPosition)
        {
            _nextPosition = (_nextPosition == _pointA.position) ? _pointB.position : _pointA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Joueur"))
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Joueur"))
        {
            other.gameObject.transform.parent = null;
        }
    }
}
