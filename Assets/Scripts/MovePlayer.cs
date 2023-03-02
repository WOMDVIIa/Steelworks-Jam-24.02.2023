using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] GameObject planePrefab;
    
    float sinArgument;
    float horizontalInput;
    [SerializeField] float forceMultiplayer;
    [SerializeField] float rotationMultiplayer = 50;
    [SerializeField] float force;

    GameObject newPlane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        force = ThrowForce();
        //ThrowPlane(force);

    }

    void RotatePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(Vector3.back, horizontalInput * rotationMultiplayer * Time.deltaTime);
    }

    void ThrowPlane(float force)
    {
        newPlane = Instantiate(planePrefab, transform.position, transform.rotation);
        newPlane.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * (1 + force) * forceMultiplayer, ForceMode.Impulse);
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
