using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public int health = 1;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {   
        Move();
        Die();
    }

    private void Move() {
        this.transform.LookAt(new Vector3(player.transform.position.x, 1.88F, player.transform.position.z));
    }

    private void Die() {
        if (health <= 0) {
            print(this.gameObject.name + "was killed!");
            Destroy(this.gameObject);
            player.hits++;
        }
    }
}
