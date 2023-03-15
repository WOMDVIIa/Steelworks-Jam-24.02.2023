using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRightPlanes : MonoBehaviour
{
    [SerializeField] GameObject[] writePlanes;
    [SerializeField] GameObject[] drawPlanes;
    [SerializeField] GameObject[] mathPlanes;

    public void ShowPlanes()
    {
        for (int i = 0; i < GameManager.instance.maxOrdersPerType; i++)
        {
            if (i < GameManager.instance.activeOrders[0])
            {
                writePlanes[i].SetActive(true);
            }

            if (i < GameManager.instance.activeOrders[1])
            {
                drawPlanes[i].SetActive(true);
            }

            if (i < GameManager.instance.activeOrders[2])
            {
                mathPlanes[i].SetActive(true);
            }
        }
    }
}
