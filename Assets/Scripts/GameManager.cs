using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerInside = false;
    public int maxOrdersPerType;
    public int[] activeOrders;
    public int noOfPlaneTypes;
    //public GameObject[] allPlanesInPlaneMenu;   // to remove
    public GameObject[] stuffPlanesInPlaneMenu;
    public GameObject[][] orderPlanesInPlaneMenu;
    public GameObject activePlaneImage;
    public float[] hiredPersonSkillSet;
    public GameObject hiredPerson;
    public GameObject planeMenu;

    [SerializeField] GameObject orderPrefab;
    [SerializeField] GameObject[] sellectedPlanePrefabs;


    OrderInfo[][] activeOrdersTable; // public to check
    public int selectedPlaneIndex;
    

    int difficulty = 2;     // temp to set single value of difficulty, will be changed to random
    int assignPlaneIndex = 1; // index in stuffPlanesInPlaneMenu table

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            CreateOrdersTables();
            FillOrderPlanesTable();
            hiredPersonSkillSet = new float[noOfPlaneTypes];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void CreateOrdersTables()
    {
        activeOrders = new int[noOfPlaneTypes];

        activeOrdersTable = new OrderInfo[noOfPlaneTypes][];
        orderPlanesInPlaneMenu = new GameObject[noOfPlaneTypes][];
        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            activeOrdersTable[i] = new OrderInfo[maxOrdersPerType];
            orderPlanesInPlaneMenu[i] = new GameObject[maxOrdersPerType];
        }
    }

    void FillOrderPlanesTable()
    {
        if (!planeMenu.activeSelf)
        {
            planeMenu.SetActive(true);
        }

        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            string tempPlaneName = "";

            switch (i)
            {
                case 2:
                    tempPlaneName = "Math";
                    break;

                case 1:
                    tempPlaneName = "Write";
                    break;

                case 0:
                    tempPlaneName = "Draw";
                    break;
            }

            //Debug.Log(tempPlaneName);

            for (int j = 0; j < maxOrdersPerType; j++)
            {
                orderPlanesInPlaneMenu[i][j] = GameObject.Find(tempPlaneName + j);
                //orderPlanesInPlaneMenu[i][j].SetActive(false);
            }
        }

        HideConditionalPlanse();
        planeMenu.SetActive(false);
    }

    public void HideConditionalPlanse()
    {
        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            for (int j = 0; j < maxOrdersPerType; j++)
            {
                 orderPlanesInPlaneMenu[i][j].SetActive(false);
            }
        }

        stuffPlanesInPlaneMenu[assignPlaneIndex].SetActive(false);
    }

    public void ShowRightPlanesInMenu()
    {
        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            for (int j = 0; j < maxOrdersPerType; j++)
            {
                if (j < activeOrders[i])
                {
                    orderPlanesInPlaneMenu[i][j].SetActive(true);
                }
            }
        }

        if (hiredPerson != null)
        {
            stuffPlanesInPlaneMenu[assignPlaneIndex].SetActive(true);
        }
    }

    public void DeselectAll()
    {
        for (int i = 0; i < stuffPlanesInPlaneMenu.Length; i++)
        {
            stuffPlanesInPlaneMenu[i].GetComponent<PlaneSelect>().Deselect();
        }

        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            for (int j = 0; j < maxOrdersPerType; j++)
            {
                orderPlanesInPlaneMenu[i][j].GetComponent<PlaneSelect>().Deselect();
            }
        }
    }

    public void FillSelectedPlaneIndex(GameObject activePlane)
    {
        for (int i = 0; i < stuffPlanesInPlaneMenu.Length; i++)
        {
            if (activePlane == stuffPlanesInPlaneMenu[i])
            {
                selectedPlaneIndex = i;
            }
        }

        for (int i = 0; i < noOfPlaneTypes; i++)
        {
            for (int j = 0; j < maxOrdersPerType; j++)
            {
                if (activePlane == orderPlanesInPlaneMenu[i][j])
                {
                    selectedPlaneIndex = 10 * (1 + i) + j;
                }
            }
        }

        activePlaneImage.GetComponent<ChangeActivePlaneSprite>().ChangeSprite(selectedPlaneIndex);
    }

    public void CheckAndGenerateOrder()
    {
        int generatedOrderIndex = Random.Range(0, noOfPlaneTypes);
        if (activeOrders[generatedOrderIndex] == maxOrdersPerType)
        {
            DestroyFirstOrder(generatedOrderIndex);
            SwapOrdersUp(generatedOrderIndex);
            GenerateOrder(generatedOrderIndex, maxOrdersPerType - 1);
        }
        else
        {
            GenerateOrder(generatedOrderIndex, activeOrders[generatedOrderIndex]);
        }        
    }

    void GenerateOrder(int index, int newPlaneNumber)
    {
        GameObject tempObject = Instantiate(orderPrefab);
        activeOrdersTable[index][newPlaneNumber] = tempObject.GetComponent<OrderInfo>();
        activeOrdersTable[index][newPlaneNumber].orderTypeIndex = index;
        activeOrdersTable[index][newPlaneNumber].orderDifficulty = difficulty;

        if (activeOrders[index] < maxOrdersPerType)
        {
            activeOrders[index]++;
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
