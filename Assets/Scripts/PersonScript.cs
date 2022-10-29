using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PersonScript : MonoBehaviour
{
    
    protected Rigidbody _rigidbody;
    
    [SerializeField]
    [Range(1f, 1000f)]
    protected float _speed;

    [SerializeField]
    [Range(200f, 1000f)]
    protected float _force;

    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(MoveForward());
    }

    private IEnumerator MoveForward()
    {
        while (true)
        {
            _rigidbody.velocity = transform.forward * _speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    
}
