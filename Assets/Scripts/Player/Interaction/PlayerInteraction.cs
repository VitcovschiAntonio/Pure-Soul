using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private bool _canInteract;
    [SerializeField] private  Button _interactButton;
    private NPCDialogue _currentNPC;


    // Update is called once per frame
    void FixedUpdate()
    {
         if (_canInteract)
        {  
            if(_currentNPC != null)
            {
                _currentNPC.StartDialogue();
            }
        }
    }
 
     public void OnInteractInput(float interactInput)
    {
        if(interactInput > 0f)
        {
            _canInteract = true;
        }
        else{
            _canInteract = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
         if (collision.collider.CompareTag("NPC"))
         {
            _interactButton.gameObject.SetActive(true);
            _currentNPC = collision.collider.GetComponent<NPCDialogue>();  
         }
    }

    void OnCollisionExit(Collision collision)
    {
         if (collision.collider.CompareTag("NPC"))
        {
            _interactButton.gameObject.SetActive(false);
        }
    }

}
