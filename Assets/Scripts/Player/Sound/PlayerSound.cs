using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
     private AudioClip[] _footSteps;
      // Drag your audio clip into this field in the Inspector
      [SerializeField]
      private AudioClip _dashSound;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        

    }

   private void Step()
   {
    AudioClip clip = GetRandomClip();
    _audioSource.PlayOneShot(clip);
   }

   private void Dash()
   {
    AudioClip clip = _dashSound;
    _audioSource.PlayOneShot(clip);
   }

   private AudioClip GetRandomClip()
   {
    return _footSteps[UnityEngine.Random.Range(0,_footSteps.Length)];
   }
   
}
