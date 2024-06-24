using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : Tower
{
    public float slowAmount = 0.5f;  // Ejemplo de declaración de slowAmount
    public float slowDuration = 3f;  // Ejemplo de declaración de slowDuration

    protected override void Attack(GameObject enemy)
    {
        // Implementación específica de cómo la SlowTower ataca al enemigo
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.ApplySlow(slowAmount, slowDuration); // Aquí se utiliza slowAmount y slowDuration
        }
    }
}

