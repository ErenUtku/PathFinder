using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitpoints = 50;

    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void KillEnemy()
    {        
        if (hitpoints <= 0)
        {
            var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            vfx.Play();
            AudioSource.PlayClipAtPoint(enemyDeathSFX,Camera.main.transform.position);
            Destroy(vfx.gameObject, vfx.main.duration);

            Destroy(gameObject);
        }
    }

    private void ProcessHit()
    {
        hitpoints = hitpoints -1;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);
    }
}
