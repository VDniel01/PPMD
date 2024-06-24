using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;        // Velocidad de movimiento inicial del enemigo
    private float originalSpeed;    // Almacena la velocidad original del enemigo
    private bool isSlowed = false;  // Indica si el enemigo est� ralentizado actualmente

    protected virtual void Start()
    {
        originalSpeed = speed;     // Al inicio, guarda la velocidad original
    }


    void Update()
    {
        // Movimiento del enemigo en la direcci�n hacia adelante (z) con la velocidad actual
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    // M�todo para aplicar ralentizaci�n al enemigo
    public void ApplySlow(float slowAmount, float duration)
    {
        if (!isSlowed)
        {
            speed *= (1f - slowAmount);     // Reduce la velocidad seg�n el porcentaje de ralentizaci�n
            isSlowed = true;                // Marca al enemigo como ralentizado
            Invoke("RemoveSlow", duration); // Programa la eliminaci�n de la ralentizaci�n despu�s de cierta duraci�n
        }
    }

    // M�todo para quitar la ralentizaci�n y restaurar la velocidad original
    void RemoveSlow()
    {
        speed = originalSpeed;  // Restaura la velocidad original del enemigo
        isSlowed = false;       // Marca al enemigo como no ralentizado
    }
}
