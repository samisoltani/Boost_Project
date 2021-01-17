using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    #region Fields
    [SerializeField] float rcsThrust;
    [SerializeField] float mainThrust;

    Rigidbody rigidBody;
    AudioSource audioSource;
    #endregion

    #region Level1
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Ok");
                break;

            case "Fuel":
                print("Fuel");
                break;

            default:
                print("Dead");
                break;
        }

    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) //can thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        rigidBody.freezeRotation = false;
    }
    #endregion
}//end of class
