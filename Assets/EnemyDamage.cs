using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitpoints = 50;
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitpoints = hitpoints -1;
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
