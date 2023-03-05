using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInside : MonoBehaviour
{
    public float destinationX;
    public int direction;

    [SerializeField] GameObject objectToMove;
    float frameJumpMultiplayer = 100;

    private void OnMouseDown()
    {
        StartCoroutine(SingleFrameDelay());        
    }

    IEnumerator SingleFrameDelay()
    {
        if (direction > 0)
        {
            while (objectToMove.transform.position.x < destinationX)
            {
                yield return new WaitForSeconds(0.01f);
                objectToMove.transform.Translate(Vector3.right * direction * frameJumpMultiplayer * Time.deltaTime);
            }
        }
        else
        {
            while (objectToMove.transform.position.x > destinationX)
            {
                yield return new WaitForSeconds(0.01f);
                objectToMove.transform.Translate(Vector3.right * direction * frameJumpMultiplayer * Time.deltaTime);
            }
        }
        MoveToFixedPosition();
    }

    void MoveToFixedPosition()
    {
        objectToMove.transform.position = new Vector3(destinationX, 1, -2);
    }
}
