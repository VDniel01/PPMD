using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    private float movementSpeed = 10f; // Velocidad de movimiento del enemigo r�pido

    protected override void Start()
    {
        base.Start(); // Llama al m�todo Start de la clase base (Enemy)

        // Inicializar el enemigo r�pido con la velocidad adecuada
        speed = movementSpeed;
    }
}
