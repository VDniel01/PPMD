using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    private float movementSpeed = 10f; // Velocidad de movimiento del enemigo rápido

    protected override void Start()
    {
        base.Start(); // Llama al método Start de la clase base (Enemy)

        // Inicializar el enemigo rápido con la velocidad adecuada
        speed = movementSpeed;
    }
}
