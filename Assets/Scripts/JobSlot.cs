using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobSlot : MonoBehaviour
{
    public GameObject employer;
    public GameObject table;

    public GameObject[] tablesWithEQ;

    public enum tableType
    {
        empty = 0,
        write = 1,
        draw = 2,
        maths = 3
    }

    public int tableIndex = (int)tableType.empty;

    private void OnMouseOver()
    {
        if (employer != null)
        {
            employer.GetComponent<PersonStats>().OnMouseOver();
        }
    }

    private void OnMouseExit()
    {
        if (employer != null)
        {
            employer.GetComponent<PersonStats>().OnMouseExit();
        }
    }
}
