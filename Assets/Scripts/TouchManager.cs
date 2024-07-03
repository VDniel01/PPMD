using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject normalTowerPrefab;
    public GameObject slowTowerPrefab;

    private Dictionary<GameObject, bool> towerPlaces = new Dictionary<GameObject, bool>();
    private GameObject selectedTowerPrefab;

    void Start()
    {
        GameObject[] towerPlaceObjects = GameObject.FindGameObjectsWithTag("TowerPlace");
        foreach (GameObject towerPlace in towerPlaceObjects)
        {
            towerPlaces.Add(towerPlace, false);
        }

        selectedTowerPrefab = normalTowerPrefab; // Default to normal tower
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            if (touch.phase == TouchPhase.Began)
            {
                GameObject hitObject = GetHitObject(touchPosition);
                if (hitObject != null && hitObject.CompareTag("TowerPlace") && !towerPlaces[hitObject])
                {
                    PlaceTower(hitObject, hitObject.transform.position);
                }
            }
        }
    }

    GameObject GetHitObject(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    void PlaceTower(GameObject towerPlace, Vector3 position)
    {
        if (selectedTowerPrefab != null)
        {
            Instantiate(selectedTowerPrefab, position, Quaternion.identity);
            towerPlaces[towerPlace] = true; // Mark the spot as occupied
        }
    }

    public void SelectNormalTower()
    {
        selectedTowerPrefab = normalTowerPrefab;
        Debug.Log("Normal Tower selected.");
    }

    public void SelectSlowTower()
    {
        selectedTowerPrefab = slowTowerPrefab;
        Debug.Log("Slow Tower selected.");
    }

}
