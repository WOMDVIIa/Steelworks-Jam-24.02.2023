using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject orderPrefab;
    public OrderInfo[][] activeOrdersTable;

    public int [] planes;
    public int maxOrdersPerType;
    public int noOfPlaneTypes;
    public GameObject [] allPlanes;
    public int selectedPlaneIndex;

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
        planes[0] = 0;  //iloœæ czekaj¹cych zamówieñ danego typu (ta wartoœæ bêdzie gdzie indziej zmieniana, tu dodana do testów)
        planes[1] = 0;
        planes[2] = 0;

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

    public void GenerateOrder()
    {
        int generatedOrderIndex = Random.Range(0, noOfPlaneTypes);
        if (planes[generatedOrderIndex] == 5)
        {
            // rage, destroy 1 plane
        }
        else
        {
            GameObject tempObject = Instantiate(orderPrefab);
            activeOrdersTable[generatedOrderIndex][planes[generatedOrderIndex]] = tempObject.GetComponent<OrderInfo>();
            activeOrdersTable[generatedOrderIndex][planes[generatedOrderIndex]].orderTypeIndex = generatedOrderIndex;
            planes[generatedOrderIndex]++;
        }
        
    }
}
