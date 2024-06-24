using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;        // Velocidad de movimiento inicial del enemigo
    private float originalSpeed;    // Almacena la velocidad original del enemigo
    private bool isSlowed = false;  // Indica si el enemigo está ralentizado actualmente

    protected virtual void Start()
    {
        originalSpeed = speed;     // Al inicio, guarda la velocidad original
    }


    void Update()
    {
        // Movimiento del enemigo en la dirección hacia adelante (z) con la velocidad actual
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    // Método para aplicar ralentización al enemigo
    public void ApplySlow(float slowAmount, float duration)
    {
        if (!isSlowed)
        {
            speed *= (1f - slowAmount);     // Reduce la velocidad según el porcentaje de ralentización
            isSlowed = true;                // Marca al enemigo como ralentizado
            Invoke("RemoveSlow", duration); // Programa la eliminación de la ralentización después de cierta duración
        }
    }

    // Método para quitar la ralentización y restaurar la velocidad original
    void RemoveSlow()
    {
        speed = originalSpeed;  // Restaura la velocidad original del enemigo
        isSlowed = false;       // Marca al enemigo como no ralentizado
    }
}
