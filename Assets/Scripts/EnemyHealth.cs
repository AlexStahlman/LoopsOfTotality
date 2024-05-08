using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private bool isBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            TakeDamage(1000);
        }
    }

        public void TakeDamage(int amount)
    {
        health -= amount;
        //SFXManager.instance.PlaySFXClip(enemyHurt, transform, 1f);
        if (health <= 0)
        {
            if (isBullet)
            {
                SFXManager.instance.PlaySFXClip(enemyDeath, transform, 1f);
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {

            TakeDamage(50);
            Destroy(other.gameObject);
        }
    }
}
