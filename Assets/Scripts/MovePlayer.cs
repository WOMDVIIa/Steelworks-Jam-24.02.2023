using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] GameObject[] planePrefabs;

    [SerializeField] RectTransform throwStrengthImage;
    [SerializeField] RectTransform throwStrengthMask;
    float maskingForceMultiplayer = 97;
    float maskAndImageOffset = 107;

    float force;
    float sinArgument;
    float horizontalInput;
    float forceMultiplayer = 7;
    float rotationMultiplayer = 50;

    GameObject newPlane;
    int newDeskIndexInPlaneMenu = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.planeMenu.activeSelf)
        {
            RotatePlayer();
            force = ThrowForce();
            throwStrengthMask.anchoredPosition = new Vector3(force * maskingForceMultiplayer - maskAndImageOffset, 40, 0);
            throwStrengthImage.anchoredPosition = new Vector3(- force * maskingForceMultiplayer + maskAndImageOffset, 0, 0);
        }
    }

    void RotatePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(Vector3.back, horizontalInput * rotationMultiplayer * Time.deltaTime);
    }

    void ThrowPlane()
    {
        if (!GameManager.instance.playerInside)
        {
            newPlane = Instantiate(planePrefabs[0], transform.position, transform.rotation);
            AddForceToPlane(newPlane);
            //newPlane.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * (1 + force) * forceMultiplayer, ForceMode.Impulse);
        }
        else
        {
            if (GameManager.instance.selectedPlaneIndex == newDeskIndexInPlaneMenu)
            {
                newPlane = Instantiate(planePrefabs[1], transform.position, transform.rotation);
                AddForceToPlane(newPlane);
            }
            else
            {
                newPlane = Instantiate(planePrefabs[0], transform.position, transform.rotation);
                AddForceToPlane(newPlane);
            }
        }
    }

    void AddForceToPlane(GameObject plane)
    {
        plane.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * (1 + force) * forceMultiplayer, ForceMode.Impulse);
    }

    float ThrowForce()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sinArgument += 0.01f;
        }
        else if (sinArgument != 0)
        {
            ThrowPlane(/*force*/);
            sinArgument = 0;
        }
        return Mathf.Sin(sinArgument) * Mathf.Sin(sinArgument);
    }
}
