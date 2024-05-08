using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float timer = 5;
    [SerializeField] private AudioClip enemyFire;
    private float bulletTime;

    public GameObject enemyBullet;
    public GameObject enemyBulletSpawn;
    public float bulletSpeed;
    private GameObject bulletObj;
    int layerMask;
    RaycastHit hit;
    private void Start()
    {
        layerMask = 3;
    }
    private void Update()
    {
                ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        bulletObj = Instantiate(enemyBullet, enemyBulletSpawn.transform.position, enemyBulletSpawn.transform.rotation) as GameObject;
        Rigidbody rb = bulletObj.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.TransformDirection(Vector3.forward) * bulletSpeed, ForceMode.Impulse);
        SFXManager.instance.PlaySFXClip(enemyFire, transform, 1f);
        Destroy(bulletObj, 5f);
    }

    //this may work
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            Destroy(bulletObj);
        }
    }


}
