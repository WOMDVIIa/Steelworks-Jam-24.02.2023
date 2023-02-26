using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] GameObject planePrefab;
    
    float sinArgument;
    float horizontalInput;
    float rotationMultiplayer = 30;
    [SerializeField] float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        force = ThrowForce();
        ThrowPlane(force);

    }

    void RotatePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(Vector3.back, horizontalInput * rotationMultiplayer * Time.deltaTime);
    }

    void ThrowPlane(float force)
    {
         force = 0;
    }

    float ThrowForce()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sinArgument += 0.01f;
        }
        else if (sinArgument != 0)
        {
            ThrowPlane(force);
            sinArgument = 0;
        }
        return Mathf.Sin(sinArgument) * Mathf.Sin(sinArgument);
    }
}
