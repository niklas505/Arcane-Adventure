using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectilePool : MonoBehaviour
{
    [SerializeField]
    private float poolSize;
    [SerializeField]
    GameObject projectilePrefab;

    private List<PlayerProjectile> pool;

    public static PlayerProjectilePool Instance;

    void Awake() {
        Instance = GetComponent<PlayerProjectilePool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerProjectile Instantiate(Vector3 position, Quaternion rotation) {
        PlayerProjectile projectile = pool[0];
        projectile.transform.position = position;
        projectile.transform.rotation = rotation;
        pool.Remove(projectile);
        
        return projectile;
    }

    public void ReturnToPool(PlayerProjectile projectile) {
        projectile.transform.position = transform.position;
        pool.Add(projectile);
    }

    void InitializePool() {
        pool = new List<PlayerProjectile>();
        for (int i = 0; i < poolSize; i++) {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            pool.Add(projectile.GetComponent<PlayerProjectile>());
        }
    }

}

