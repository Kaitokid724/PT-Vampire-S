using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, enemyDeathSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string Clip)
    {
        switch (Clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
        }
    }
}
