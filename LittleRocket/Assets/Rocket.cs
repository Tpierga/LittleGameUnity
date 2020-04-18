using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rcsThrust = 100.0f;
    [SerializeField] private float mainThrust = 100.0f;
    Rigidbody _rigidbody;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateInput();
        Thrust();

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "friendly":
                print("ok");
                break;
            case "fuel":
                print("fuel");
                break;
            default:
                print("DEAD");
                break;
        }
    }

    private void RotateInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * (rcsThrust * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * (rcsThrust * Time.deltaTime));
        }
    }

    private void Thrust()
    {
        _rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up*mainThrust);
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }

        _rigidbody.freezeRotation = false;

    }
}
