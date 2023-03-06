using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 _startPosition;
    [SerializeField] Vector3 _movementVector; // Controls the endpoint in 3D Space
    [SerializeField] [Range(0,1)] float _movementFactor;
    [SerializeField] float _period = 4f; // Controls speed of movement

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_period  <= Mathf.Epsilon) { return; }
        float _cycles = Time.time / _period; // Continually grows over time

        const float TAU = Mathf.PI * 2; // Constant value: 6.281 denotes 2 radians (full domain of Sin)
        float _rawSinWave = Mathf.Sin(TAU * _cycles); // Going from [-1,1] (full range of Sin)

        _movementFactor = (_rawSinWave + 1f) / 2f; // Converts value to [0,1]

        Vector3 _offset = _movementVector * _movementFactor;
        transform.position = _startPosition + _offset;
    }
}
