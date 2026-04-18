using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioListener : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioSources = new List<AudioSource>();
   
    void OnEnable()
    {
        Enemy.OnEnemyDestroyed += PlayEnemyDestroyedSFX;
        PlayerController.OnPlayerFired += PlayBulletFireSFX;
        
    }

    void OnDisable()
    {
        Enemy.OnEnemyDestroyed -= PlayEnemyDestroyedSFX;
        PlayerController.OnPlayerFired -= PlayBulletFireSFX;
    }

    void PlayEnemyDestroyedSFX()
    {
        audioSources[0].Play();
    }

    void PlayBulletFireSFX()
    {
        audioSources[1].Play();
    }
}
