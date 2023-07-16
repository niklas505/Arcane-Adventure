using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectilePool : MonoBehaviour
{
    [SerializeField]
    private float poolSize;
    [SerializeField]
    GameObject projectilePrefab;

    private List<EnemyProjectile> pool;

    public static EnemyProjectilePool Instance;

    void Awake() {
        Instance = GetComponent<EnemyProjectilePool>();
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

    public EnemyProjectile Instantiate(Vector3 position, Quaternion rotation) {
        EnemyProjectile projectile = pool[0];
        projectile.transform.position = position;
        projectile.transform.rotation = rotation;
        pool.Remove(projectile);
        
        return projectile;
    }

    public void ReturnToPool(EnemyProjectile projectile) {
        projectile.transform.position = transform.position;
        pool.Add(projectile);
    }

    void InitializePool() {
        pool = new List<EnemyProjectile>();
        for (int i = 0; i < poolSize; i++) {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            pool.Add(projectile.GetComponent<EnemyProjectile>());
        }
    }

}

