using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Rocket : MonoBehaviour
{
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
        ProcessInput();

    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _audioSource.Stop();
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
