using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool planeMenuOn = false;    
    public int maxOrdersPerType;
    public int[] planes;
    public int noOfPlaneTypes;
    public GameObject[] allPlanesInPlaneMenu;

    [SerializeField] GameObject planeMenuObject;
    [SerializeField] GameObject orderPrefab;
    [SerializeField] GameObject[] sellectedPlanePrefabs;


    OrderInfo[][] activeOrdersTable; // public to check
    public int selectedPlaneIndex;
    

    int difficulty = 2;     // temp to set single value of difficulty, will be changed to random

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
        //planes[0] = 0;  //ilo�� czekaj�cych zam�wie� danego typu (ta warto�� b�dzie gdzie indziej zmieniana, tu dodana do test�w)
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
        for (int i = 0; i < allPlanesInPlaneMenu.Length; i++)
        {
            allPlanesInPlaneMenu[i].GetComponent<PlaneSelect>().Deselect();
        }
    }

    public void FillSelectedPlaneIndex(GameObject activePlane)
    {
        for (int i = 0; i < allPlanesInPlaneMenu.Length; i++)
        {
            if (activePlane == allPlanesInPlaneMenu[i])
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
        if (planeMenuObject.activeSelf)
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

    void PrintOrders() //Debug
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
