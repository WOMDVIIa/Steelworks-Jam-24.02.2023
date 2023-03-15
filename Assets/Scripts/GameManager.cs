using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool planeMenuOn = false;
    public bool playerInside = false;
    public int maxOrdersPerType;
    public int[] planes;
    public int noOfPlaneTypes;
    public GameObject[] allPlanesInPlaneMenu;
    public GameObject activePlaneImage;
    public float[] hiredPersonSkillSet;
    public GameObject hiredPerson;

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
            hiredPersonSkillSet = new float[noOfPlaneTypes];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void CreatePlanesOrdersTables()
    {
        planes = new int[noOfPlaneTypes];

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
        //SetSellectedPlaneImage();
        activePlaneImage.GetComponent<ChangeActivePlaneSprite>().ChangeSprite(selectedPlaneIndex);
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
