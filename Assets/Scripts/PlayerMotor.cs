using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;
    
    private Vector3 _velocity;
    private Vector3 _rotation;
    private Vector3 _camRotation;
    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 velocity)
    {
        _velocity = velocity;
    }

    public void Rotate(Vector3 rotation)
    {
        _rotation = rotation;
    }
    
    public void RotateCamera(Vector3 camRotation)
    {
        _camRotation = camRotation;
    }
    
    private void Update()
    {
        DoMovement();
        DoRotation();
    }

    private void DoMovement()
    {
        if (_velocity != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
        }
    }

    private void DoRotation()
    {
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(_rotation));
        _cam.transform.Rotate(-_camRotation);
    }
}
