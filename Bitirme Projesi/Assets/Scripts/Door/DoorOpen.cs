using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float distance;
    public GameObject actionKey, actionText, hinge;
    public AudioSource doorAuido;

    void Update()
    {
        distance = PlayerRay.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (distance <= 2)
        {
            actionKey.SetActive(true);
            actionText.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            actionText.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            if (distance <= 2)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                actionText.SetActive(false);
                hinge.GetComponent<Animation>().Play("DoorOpen");
                doorAuido.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }
}
