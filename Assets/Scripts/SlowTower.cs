using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : Tower
{
    public float slowAmount = 0.5f;  // Ejemplo de declaraci�n de slowAmount
    public float slowDuration = 3f;  // Ejemplo de declaraci�n de slowDuration

    protected override void Attack(GameObject enemy)
    {
        // Implementaci�n espec�fica de c�mo la SlowTower ataca al enemigo
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.ApplySlow(slowAmount, slowDuration); // Aqu� se utiliza slowAmount y slowDuration
        }
    }
}

