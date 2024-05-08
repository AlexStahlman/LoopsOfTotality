using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] public PlayerShoot player;
    public int Randomed;
    private void Start()
    {
    }
    void buffPlayer()
    {
        //0-4 is actually 0-3
        Randomed = Random.Range(0, 4);
        player.magazineSize += 5;

        if (Randomed == 0)
        {
            player.reloadTime -= .5f;
        }
        if (Randomed == 1)
        {
            player.shootForce += 30;
        }
        if (Randomed == 2)
        {
            player.bulletDmg += 10;
        }
        if (Randomed == 3)
        {
            player.bulletsPerTap += 1;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //add to whatever it does
            buffPlayer();
            Destroy(gameObject);
        }
    }
}
