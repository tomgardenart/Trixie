﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    
    private ShieldComponent shieldComponent;
    
    private void Start ()
    {
        shieldComponent = Player.Instance.GetComponent<ShieldComponent>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BlockProjectiles(collision.gameObject);
        DestroyEnemies(collision.gameObject);
    }

    private void BlockProjectiles(GameObject other)
    {
        if (other.tag == "Projectile")
        {
            if (shieldComponent.IsShielding())
            {
                shieldComponent.RemoveCharge();
            }
            else if (shieldComponent.IsFiring())
            {
                shieldComponent.DisableShield();
            }
            other.GetComponent<Projectile>().DestroyByCollision();
        }
    }

    private void DestroyEnemies(GameObject other)
    {
        // TODO check if shield hits enemy
    }

    
}
