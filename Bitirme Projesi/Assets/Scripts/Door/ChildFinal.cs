using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildFinal : MonoBehaviour
{
    public float distance;
    public GameObject actionKey, actionText;

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
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }
}
