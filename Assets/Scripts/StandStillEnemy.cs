using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandStillEnemy : MonoBehaviour
{
    public Transform playerTrans;
    public int turnSpeed;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = playerTrans.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Vector3 fwd = this.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(this.transform.position, fwd * 5, Color.black);
    }

}
