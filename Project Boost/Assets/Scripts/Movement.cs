using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform _transform;

    [SerializeField] private float _thrust = 750f;
    [SerializeField] private float _pitch = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {        
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up * _thrust * Time.deltaTime);
            Debug.Log("Pressed space; Thrusting");
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_pitch);
            Debug.Log("Pressed A; Rotating Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_pitch);
            Debug.Log("Pressed D; Rotating Right");
        }
    }

    void ApplyRotation(float pitchThisFrame)
    {
        _rigidbody.freezeRotation = true;
        _transform.Rotate(Vector3.forward * pitchThisFrame * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }
}
