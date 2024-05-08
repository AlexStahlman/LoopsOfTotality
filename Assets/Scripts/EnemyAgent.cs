using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private Transform playerTrans;
    [SerializeField] public currentState currentState;
    [SerializeField] private float detectionRange;

    [Header("Raycast")]
    private NavMeshHit hit;
    private bool theRay;
    public Vector3 direction;

    public Transform player;
    [SerializeField] private float timer = 5;
    [SerializeField] private AudioClip enemyFire;
    private float bulletTime;

    public GameObject enemyBullet;
    public GameObject enemyBulletSpawn;
    public float bulletSpeed;
    private GameObject bulletObj;
    private void Start()
    {
    }
    // Update is called once per frame
    private void Update()
    {
        /*
        Ray ray = new Ray(agent.transform.position, playerTrans.transform.position - agent.transform.position);
        Debug.DrawRay(agent.transform.position, playerTrans.transform.position - agent.transform.position);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
        */
        State();
    }
    public void State()
    {
        // this one \/ is a first try at it, but its here incase the agent.Raycast becomes stupid
        //theRay = NavMesh.Raycast(transform.position, playerTrans.position, out hit, NavMesh.AllAreas);
        if (playerTrans)
        {
            theRay = agent.Raycast(playerTrans.position, out hit);
        }
        Debug.DrawRay(hit.position, Vector3.up, Color.green);
        if (currentState == currentState.Idle)
        {
            //theRay is a boolean raycast that returns true if connected
            if (!theRay)
            {
                this.currentState = currentState.Moving;
            }
        }
        else if (this.currentState == currentState.Moving)
        {
                agent.SetDestination(playerTrans.position);
            //IF THE RAYCAST IS LOST, GOTO IDLE!!!
            if (theRay)
            {
                this.currentState = currentState.Idle;
            }
            ShootAtPlayer();
        }
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


}
public enum currentState
{
    Idle,
    Moving
}