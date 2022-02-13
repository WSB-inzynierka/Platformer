 using UnityEngine;
 
 public class AudioClass : MonoBehaviour
 {
     public AudioSource _audioSource;
     public AudioSource _audioSource2;

     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource2.isPlaying) return;
         _audioSource2.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
 }