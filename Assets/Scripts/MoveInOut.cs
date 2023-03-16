using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveInOut : MonoBehaviour, IPointerClickHandler
{
    public float destinationX;
    public int direction;

    [SerializeField] GameObject rightBanner;
    [SerializeField] GameObject leftBanner;
    [SerializeField] GameObject objectToMove;
    float frameJumpMultiplayer = 100;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameManager.instance.planeMenu.activeSelf)
        {
            StartCoroutine(SingleFrameDelay());
        }
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
        ToggleBannersVisibitily();
    }

    void MoveToFixedPosition()
    {
        objectToMove.transform.position = new Vector3(destinationX, 1, -2);
    }

    void ToggleBannersVisibitily()
    {
        if (rightBanner.activeSelf == true)
        {
            leftBanner.SetActive(true);
            rightBanner.SetActive(false);
            GameManager.instance.activePlaneImage.GetComponent<ChangeActivePlaneSprite>().ChangeSprite(GameManager.instance.selectedPlaneIndex);
            GameManager.instance.playerInside = true;
        }
        else
        {
            rightBanner.SetActive(true);
            leftBanner.SetActive(false);
            GameManager.instance.activePlaneImage.GetComponent<ChangeActivePlaneSprite>().ChaneToHireSprite();
            GameManager.instance.playerInside = false;
        }
    }
}
