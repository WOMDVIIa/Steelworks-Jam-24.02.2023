using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float sinArgument;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        force = ThrowForce();
    }

    float ThrowForce()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sinArgument += 0.01f;
        }

        return Mathf.Sin(sinArgument) * Mathf.Sin(sinArgument);
    }
}
