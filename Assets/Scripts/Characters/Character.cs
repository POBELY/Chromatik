using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    public int health = 3;
    public int maxHealth = 3;

    // Weapon : dedicated class ?
    public Attack swordSlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void Hit(int damages)
    {
        health -= damages;
    }

    virtual protected void Die()
    {
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }

    protected void Attack()
    {
        swordSlash.startAttack();
    }

}
