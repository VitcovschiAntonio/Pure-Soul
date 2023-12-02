using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    
    [SerializeField] private Canvas _dialogBox;
    
     [SerializeField] private TextMeshProUGUI _dialogueText;
     private string _sentence;
     private string[] _dialogues;
     private int _sentenceIndex;
     private int _dialogueSize;
     [SerializeField] private string _defaultChat;
     void Start()
     {
        _sentenceIndex = 0;
     }
     void Update()
     {
        Debug.Log(_sentenceIndex);
        Debug.Log(_dialogueSize);
     }
    public void InitiateDialogue(string[] dialogue)
    {
        _dialogues = dialogue;
        _dialogueSize = _dialogues.Length;
        if(_sentenceIndex == _dialogueSize)
        {
            _sentence = _defaultChat;
        }
        else{
        _sentence = _dialogues[_sentenceIndex];

        }
        StartDialogue();

    }
    public void StartDialogue()
    {
        _dialogueText.text = "";
        _dialogBox.gameObject.SetActive(true);
        DisplayNextSentence();
    }
    
    private void DisplayNextSentence()
    {
        if(_sentence.Length == 0 )
        {
            EndDialogue();
            return;
        }
        StopAllCoroutines();
        StartCoroutine(DisplaySentence(_sentence));
    }
    IEnumerator DisplaySentence(string sentence)
    {
        _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if(letter == '.')
            {
                yield return new WaitForSeconds(1f);
                _dialogueText.text = "";

            }
            else{
                _dialogueText.text += letter;
               
            }
            yield return null;
        }
         yield return new WaitForSeconds(2f);

        EndDialogue();
    }
    public void EndDialogue()
    {
        _dialogueText.text = "";
        _dialogBox.gameObject.SetActive(false);
        if(_sentenceIndex == _dialogueSize)
        {
            _sentence = _defaultChat;

            
        }
        else{
            _sentenceIndex+=1;
        }
        

    }
}
