using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private String[] _sentences;
    [SerializeField] private Dialogue _dialogue;
 
    

  

    public void StartDialogue()
    {
        Debug.Log("Start dialogue from NPCInteraction");

        _dialogue.InitiateDialogue(_sentences);
    }
    void EndDialogue()
    {
        _dialogue.EndDialogue();
    }
}
