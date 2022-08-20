using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _thrustAmount = 100f;
    [SerializeField] private float _rotationSpeed = 1.0f;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
            _rigidbody.AddRelativeForce(Vector3.up * _thrustAmount * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationDirection)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }
}
