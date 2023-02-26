using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool planeMenuOn = false;

    public OrderInfo[][] activeOrdersTable;
    public int [] planes;
    public int maxOrdersPerType;
    public int noOfPlaneTypes;
    public GameObject [] allPlanes;
    public int selectedPlaneIndex;
    public int difficulty = 2;

    [SerializeField] GameObject planeMenuObject;
    [SerializeField] GameObject orderPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            CreatePlanesOrdersTables();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlanesOrdersTables()
    {
        planes = new int[noOfPlaneTypes];
        //planes[0] = 0;  //iloœæ czekaj¹cych zamówieñ danego typu (ta wartoœæ bêdzie gdzie indziej zmieniana, tu dodana do testów)
        //planes[1] = 0;
        //planes[2] = 0;

        activeOrdersTable = new OrderInfo[noOfPlaneTypes][];
        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            activeOrdersTable[i] = new OrderInfo[maxOrdersPerType];
        }
    }

    public void DeselectAll()
    {
        for (int i = 0; i < allPlanes.Length; i++)
        {
            allPlanes[i].GetComponent<PlaneSelect>().Deselect();
        }
    }

    public void FillSelectedPlaneIndex(GameObject activePlane)
    {
        for (int i = 0; i < allPlanes.Length; i++)
        {
            if (activePlane == allPlanes[i])
            {
                selectedPlaneIndex = i;
            }
        }
    }

    public void CheckAndGenerateOrder()
    {
        int generatedOrderIndex = Random.Range(0, noOfPlaneTypes);
        if (planes[generatedOrderIndex] == maxOrdersPerType)
        {
            DestroyFirstOrder(generatedOrderIndex);
            SwapOrdersUp(generatedOrderIndex);
            GenerateOrder(generatedOrderIndex, maxOrdersPerType - 1);
        }
        else
        {
            GenerateOrder(generatedOrderIndex, planes[generatedOrderIndex]);
        }        
    }

    void GenerateOrder(int index, int newPlaneNumber)
    {
        GameObject tempObject = Instantiate(orderPrefab);
        activeOrdersTable[index][newPlaneNumber] = tempObject.GetComponent<OrderInfo>();
        activeOrdersTable[index][newPlaneNumber].orderTypeIndex = index;
        activeOrdersTable[index][newPlaneNumber].orderDifficulty = difficulty;

        if (planes[index] < maxOrdersPerType)
        {
            planes[index]++;
        }
        //PrintOrders();
    }


    void DestroyFirstOrder(int index)
    {
        Destroy(activeOrdersTable[index][0].gameObject);
        // --------------------------------------------------------------------------------------------------GENERATE RAGE
    }

    void SwapOrdersUp(int index)
    {
        for (int i = 1; i < maxOrdersPerType; i++)
        {
            activeOrdersTable[index][i - 1] = activeOrdersTable[index][i];
        }
    }

    public void TogglePlaneMenu()
    {
        if (planeMenuObject.active)
        {
            planeMenuObject.SetActive(false);
            planeMenuOn = false;
        }
        else
        {
            planeMenuObject.SetActive(true);
            planeMenuObject.GetComponent<ShowRightPlanes>().ShowPlanes();
            planeMenuOn = true;
        }
    }

    void PrintOrders() //Test
    {
        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            for (int j = 0; j < maxOrdersPerType; j++)
            {
                if (activeOrdersTable[i][j] != null)
                {
                    Debug.Log("qwe[" + i + "][" + j+ "] = " + activeOrdersTable[i][j].orderDifficulty);                
                }
            }
        }
    }
}
