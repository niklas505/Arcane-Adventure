using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 firingPoint;
    
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float maxFireRange;

    private bool shouldMove;
    private GameObject triggeringObject;
 //   [SerializeField] GameObject explosionPrefab;
 //   [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove) {
            MoveProjectile();
        }
    }

    public void OnTriggerEnter(Collider other) {
        triggeringObject = other.gameObject;
        if(triggeringObject.GetComponent<EnemyController>() != null) {
            triggeringObject.GetComponent<EnemyController>().health--;
        }
        else if (triggeringObject.GetComponent<PlayerController>() != null) {
            triggeringObject.GetComponent<PlayerController>().health--;
        }
 //       Instantiate(explosionPrefab, transform.position, transform.rotation);
        ProjectilePool.Instance.ReturnToPool(this);
        shouldMove = false;
    }

    public void activateProjectile() {
 //       audioSource.Play();
        firingPoint = transform.position;
        shouldMove = true;
    }

    void MoveProjectile() {
        if (Vector3.Distance(firingPoint, transform.position) > maxFireRange) {
            ProjectilePool.Instance.ReturnToPool(this);
            shouldMove = false;
        }
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
