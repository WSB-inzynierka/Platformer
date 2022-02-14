 using UnityEngine;
 
 public class AudioClass : MonoBehaviour
 {
     public AudioSource _audioSource;
     public AudioSource _audioSource2;

     private static AudioClass audioclassInstance;

     private void Awake()
     {
         DontDestroyOnLoad(this);

         if (audioclassInstance == null){
             audioclassInstance = this;
         }
         else {
             Destroy(gameObject);
         }


        //  DontDestroyOnLoad(transform.gameObject);
        //  _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic2()
     {
         if (_audioSource2.isPlaying) return;
         _audioSource2.Play();
     }
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
 }