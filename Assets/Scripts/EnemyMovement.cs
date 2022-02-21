using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalParticle;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint pathfinder in path)
        {
            transform.position = pathfinder.transform.position;
            yield return new WaitForSeconds(0.5f);
        }
        SelfDestruct();
    }
    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }
}
