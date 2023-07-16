using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField]
    public Transform firingPoint;
    [SerializeField]
    public float fireSpeed;

    private float lastTimeShot = 0;

    private PlayerController player;

    public static PlayerGun Instance;
    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }

    void Start() {
        player = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot() {
        if (Time.time > lastTimeShot + fireSpeed) {
            PlayerProjectile projectile = PlayerProjectilePool.Instance.Instantiate(firingPoint.position, firingPoint.rotation);
            projectile.activateProjectile();
            lastTimeShot = Time.time;
            player.shoots++;
        }
    }
}
