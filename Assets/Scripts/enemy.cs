using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }
    public void TakeDamage(int amount) {
        health = health - amount;
       
        if (health <= 0) {
            //player dies
            Die();
           
        }
    }

    void Die() {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
