using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip healthSound;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        SFXManager.instance.PlaySFXClip(backgroundMusic, transform, .4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            SFXManager.instance.PlaySFXClip(healthSound, transform, 1f);
            TakeDamage(30);
        }
    }
}
