using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 _startPosition;
    [SerializeField] Vector3 _movementVector;
    [SerializeField] [Range(0,1)] float _movementFactor;
    [SerializeField] float _period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float _cycles = Time.time / _period;
        const float TAU = Mathf.PI * 2;

        Vector3 _offset = _movementVector * _movementFactor;
        transform.position = _startPosition + _offset;
    }
}
