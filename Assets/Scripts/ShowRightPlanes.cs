using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRightPlanes : MonoBehaviour
{
    [SerializeField] GameObject[] writePlanes;
    [SerializeField] GameObject[] drawPlanes;
    [SerializeField] GameObject[] mathPlanes;

    // Start is called before the first frame update
    void Start()
    {
        //writingPlanes = new GameObject[GameManager.maxOrdersPerType];

        for (int i = 0; i < GameManager.instance.noOfPlaneTypes; i++)
        {
            if (i < GameManager.instance.planes[0])
            {
                writePlanes[i].SetActive(true);
            }

            if (i < GameManager.instance.planes[1])
            {
                drawPlanes[i].SetActive(true);
            }

            if (i < GameManager.instance.planes[2])
            {
                mathPlanes[i].SetActive(true);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
