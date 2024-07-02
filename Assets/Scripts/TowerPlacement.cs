using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject selectedTowerPrefab = TowerManager.Instance.GetSelectedTower();
        if (selectedTowerPrefab != null)
        {
            Instantiate(selectedTowerPrefab, transform.position, Quaternion.identity);
        }
    }
}
