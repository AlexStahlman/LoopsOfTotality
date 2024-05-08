using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private AudioClip fireSound;
    public GameObject bullet;
    public float shootForce, upwardForce;
    [SerializeField] public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    [SerializeField] public int magazineSize, bulletsPerTap;
    [SerializeField] public int bulletDmg;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading;
    public GameObject hitEnemy;
    public GameObject currentBullet;
    public Camera cam;
    public Transform attackPoint;

    public TMP_Text ammunitionDisplay;

    public bool allowInvoke = true;

    public EnemyHealth enemyHealth;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        if(ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        }
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKey(KeyCode.Mouse0);
        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reloading();

        //reload if empty
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reloading();

        //shooting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //find the hit position with a raycast
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //check if it hits
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75); //far away air shot
        }

        //calculate direction from attack to target
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //make spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //make the bullet
        currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;
        SFXManager.instance.PlaySFXClip(fireSound, transform, 1f);
        //add force
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(cam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if a burst
        if(bulletsShot < bulletsPerTap && bulletsPerTap > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reloading()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    

   /*private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.tag == "StandingEnemy" || collision.gameObject.tag == "MovingEnemy")
        {
            Destroy(bullet);
            //damage enemy here
            //make the current bullets closest enemytagged person the enemy health object

            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(50);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            Destroy(bullet);
        }
    }*/
}

