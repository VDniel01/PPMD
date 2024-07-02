using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : Tower
{
    public float slowAmount = 0.5f;
    public float slowDuration = 2f;

    protected override void Attack(GameObject enemy)
    {
        base.Attack(enemy);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.ApplySlow(slowAmount, slowDuration);
        }
    }
}
