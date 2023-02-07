using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform shooter;
    public GameObject bullet;
    EnemyManager enemyManager;
    public float timeBetweenShots = 0.2f;
    private float currentTime = 0f;
    public Vector3 targetOffset = Vector3.right * 5f;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootAtTarget();
    }
    public void ShootAtTarget()
    {
        if (enemyManager.currentShootingTarget)
        {
            // shooter.transform.LookAt(
            Vector3 shootPoint = enemyManager.currentShootingTarget.position + 
                targetOffset + 
                enemyManager.currentShootingTarget.forward * 50f * Mathf.PerlinNoise(Time.time * 6f, 0.0f);

            shooter.rotation = Quaternion.Slerp(shooter.rotation, Quaternion.LookRotation(shootPoint - shooter.position), Time.deltaTime * 5f);
                
            Shoot();
        }
    }

    private void Shoot()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0f)
        {
            currentTime = timeBetweenShots;
            Instantiate(bullet, shooter.transform.position, shooter.transform.rotation);
        }
    }
}
