using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject normalTowerPrefab;  // Variable para almacenar el Prefab de la torre normal

    void OnMouseDown()
    {
        // Verifica si el Prefab de la torre normal está asignado
        if (normalTowerPrefab != null)
        {
            // Instancia el Prefab de la torre normal en la posición actual del mouse
            Instantiate(normalTowerPrefab, transform.position, Quaternion.identity);
        }
        
        
    }
}
