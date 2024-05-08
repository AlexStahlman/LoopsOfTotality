using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; 
    [SerializeField] private AudioClip healthSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SFXManager.instance.PlaySFXClip(healthSound, transform, 1f);
            playerHealth.TakeDamage(30);
        }
    }
}
