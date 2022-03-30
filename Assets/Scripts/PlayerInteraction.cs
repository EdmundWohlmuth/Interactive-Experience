using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInteractObjScript = null;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
        {
            // logic goes here
            CheckInteraction();
        }      
    }

    private void CheckInteraction()
    {
        Debug.Log("this is " + currentInterObj.name);

        if (currentInteractObjScript.interType == InteractionObject.InteractableType.nothing)
        {
            //currentInteractObjScript.Nothing();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.info)
        {
            currentInteractObjScript.Info();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.pickup)
        {
            currentInteractObjScript.Pickup();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.dialoge)
        {
            currentInteractObjScript.Dialouge();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("InterObject") == true)
        {
            currentInterObj = collision.gameObject;
            currentInteractObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("InterObject") == true))
        {
            currentInterObj = null;
            currentInteractObjScript = null;
        }
    }
}
