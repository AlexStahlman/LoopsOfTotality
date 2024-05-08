using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 || other.gameObject.layer == 6 || other.gameObject.layer == 9 || other.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
