using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject normalTowerPrefab;
    public GameObject slowTowerPrefab;

    void OnMouseDown()
    {
        // Verifica si el Prefab de la torre normal est� asignado
        if (normalTowerPrefab != null)
        {
            // Instancia el Prefab de la torre normal en la posici�n actual del mouse
            Instantiate(normalTowerPrefab, transform.position, Quaternion.identity);
        }
    }
}
