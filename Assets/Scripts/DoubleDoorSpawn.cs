using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorSpawn : MonoBehaviour
{
    public GameObject boss;
    public GameObject boss2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss.SetActive(true);
            boss2.SetActive(true);
        }
    }
}
