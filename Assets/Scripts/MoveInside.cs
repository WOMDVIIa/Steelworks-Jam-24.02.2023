using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInside : MonoBehaviour
{
    [SerializeField] GameObject objectToMove;
    int moveFrames = 20;
    float frameJumpMultiplayer = 100;

    private void OnMouseDown()
    {
        StartCoroutine(SingleFrameDelay());        
    }

    IEnumerator SingleFrameDelay()
    {
        for (int i = 0; i < moveFrames; i++)
        {
            yield return new WaitForSeconds(0.01f);
            objectToMove.transform.Translate(Vector3.right * frameJumpMultiplayer * Time.deltaTime);
        }
        MoveToFixedPosition();
    }

    void MoveToFixedPosition()
    {
        objectToMove.transform.position = new Vector3(20, 1, -2);
    }
}
