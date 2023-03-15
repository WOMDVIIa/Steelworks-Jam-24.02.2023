using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlight : MonoBehaviour
{
    float instantiateTime;
    float destroyVelocityThreshold = 0.1f;

    Rigidbody ownRb;

    // Start is called before the first frame update
    void Start()
    {
        instantiateTime = Time.time;
        ownRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float lifeDuration = Time.time - instantiateTime;
        if (ownRb.velocity.magnitude < destroyVelocityThreshold && lifeDuration > 1)
        {
            ownRb.AddForce(Vector3.forward * 1000);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        //if (collision.gameObject.CompareTag("Builder"))
        //{
            
        //}
        //else if (!collision.gameObject.CompareTag("Collector"))
        //{
        //    Destroy(collision.gameObject);        
        //}
    }
}
