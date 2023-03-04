using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform _transform;
    AudioSource _audio;

    [SerializeField] AudioClip _thrusterSound;
    [SerializeField] ParticleSystem _mainThruster;
    [SerializeField] ParticleSystem _rightThrusters;
    [SerializeField] ParticleSystem _leftThrusters;
    [SerializeField] Light _thrusterLight;
    [SerializeField] private float _thrust = 1000f;
    [SerializeField] private float _pitch = 25f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _audio = GetComponent<AudioSource>();
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
            ApplyThrust();
        }
        else
        {
            _audio.Stop();
            _mainThruster.Stop();
            _thrusterLight.enabled = false;
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            _leftThrusters.Stop();
            _rightThrusters.Stop();
        }
    }


    void ApplyRotation(float pitchThisFrame)
    {
        _rigidbody.freezeRotation = true;
        _transform.Rotate(Vector3.forward * pitchThisFrame * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }

    void ApplyThrust()
    {
        _rigidbody.AddRelativeForce(Vector3.up * _thrust * Time.deltaTime);
        if (!_audio.isPlaying && !_mainThruster.isPlaying)
        {
            _audio.PlayOneShot(_thrusterSound);
            _mainThruster.Play();
            _thrusterLight.enabled = true;
        }
        Debug.Log("Pressed space; Thrusting");
    }
    void RotateRight()
    {
        if (!_rightThrusters.isPlaying)
        {
            _rightThrusters.Play();
        }
        ApplyRotation(-_pitch);
        Debug.Log("Pressed D; Rotating Right");
    }

    void RotateLeft()
    {
        if (!_leftThrusters.isPlaying)
        {
            _leftThrusters.Play();
        }
        ApplyRotation(_pitch);
        Debug.Log("Pressed A; Rotating Left");
    }
}
