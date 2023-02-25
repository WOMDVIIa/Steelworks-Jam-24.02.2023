using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int [] planes;
    public int maxOrdersPerType = 3;
    public int noOfPlaneTypes = 3;
    public GameObject [] allPlanes;
    public int selectedPlaneIndex;

    // Start is called before the first frame update
    //void Start()
    //{
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            planes = new int[noOfPlaneTypes];
            planes[0] = 3;  //iloœæ czekaj¹cych zamówieñ danego typu (ta wartoœæ bêdzie gdzie indziej zmieniana, tu dodana do testów)
            planes[1] = 1;
            planes[2] = 2;

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
}
