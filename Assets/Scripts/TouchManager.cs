using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject normalTowerPrefab;
    public GameObject slowTowerPrefab;

    private GameObject selectedTowerPrefab;
    private Dictionary<GameObject, bool> towerPlaces = new Dictionary<GameObject, bool>();

    void Start()
    {
        selectedTowerPrefab = normalTowerPrefab;
        GameObject[] towerPlaceObjects = GameObject.FindGameObjectsWithTag("TowerPlace");
        foreach (GameObject towerPlace in towerPlaceObjects)
        {
            towerPlaces.Add(towerPlace, false);
        }
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
                    PlaceTower(hitObject);
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

    void PlaceTower(GameObject towerPlace)
    {
        if (selectedTowerPrefab != null)
        {
            TowerCard towerCard = selectedTowerPrefab.GetComponent<TowerCard>();
            if (towerCard != null && GameManager.Instance.points >= towerCard.cost)
            {
                Instantiate(selectedTowerPrefab, towerPlace.transform.position, Quaternion.identity);
                towerPlaces[towerPlace] = true;
                GameManager.Instance.AddPoints(-towerCard.cost);
            }
        }
    }

    public void SelectNormalTower()
    {
        selectedTowerPrefab = normalTowerPrefab;
    }

    public void SelectSlowTower()
    {
        selectedTowerPrefab = slowTowerPrefab;
    }
}
