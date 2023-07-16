using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]
    public Transform firingPoint;
    [SerializeField]
    public float fireSpeed;

    private float lastTimeShot = 0;

    public static EnemyGun Instance;
    void Awake()
    {
        Instance = GetComponent<EnemyGun>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot() {
        if (Time.time > lastTimeShot + fireSpeed) {
            EnemyProjectile projectile = EnemyProjectilePool.Instance.Instantiate(firingPoint.position, firingPoint.rotation);
            projectile.activateProjectile();
            lastTimeShot = Time.time;
        }
    }
}
