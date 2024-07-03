using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : Tower
{
    public float slowAmount = 0.5f; // 50% slow
    public float slowDuration = 2f; // 2 seconds slow

    protected override void Attack(GameObject enemy)
    {
        base.Attack(enemy);

        // Apply slow effect to the enemy
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.ApplySlow(slowAmount, slowDuration);
        }
    }
}
