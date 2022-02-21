using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    private int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;

    private void OnTriggerEnter(Collider collision)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health = health - healthDecrease;
        healthText.text = health.ToString();
    }
    private void Start()
    {
        healthText.text = health.ToString();
    }

}
