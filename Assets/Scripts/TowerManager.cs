using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    public GameObject normalTowerPrefab;
    public GameObject slowTowerPrefab;

    private GameObject selectedTowerPrefab;

    void Awake()
    {
        Instance = this;
        selectedTowerPrefab = normalTowerPrefab; // Torre por defecto
    }

    public void SelectNormalTower()
    {
        selectedTowerPrefab = normalTowerPrefab;
    }

    public void SelectSlowTower()
    {
        selectedTowerPrefab = slowTowerPrefab;
    }

    public GameObject GetSelectedTower()
    {
        return selectedTowerPrefab;
    }
}
