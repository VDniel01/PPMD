using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    private bool isOccupied = false;

    public void PlaceTower(GameObject tower)
    {
        if (!isOccupied)
        {
            isOccupied = true;
            // Ensure tower starts shooting only when placed
            tower.GetComponent<Tower>().enabled = true;
        }
    }
}
