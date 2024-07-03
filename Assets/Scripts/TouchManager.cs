using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject normalTowerPrefab;
    public GameObject slowTowerPrefab;
    private Dictionary<GameObject, bool> towerPlaces = new Dictionary<GameObject, bool>();

    void Start()
    {
        // Marcar las casillas como no ocupadas inicialmente
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
        // Para depuración en editor usando el ratón
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            GameObject hitObject = GetHitObject(mousePosition);
            if (hitObject != null && hitObject.CompareTag("TowerPlace") && !towerPlaces[hitObject])
            {
                PlaceTower(hitObject);
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
        // Aquí puedes implementar la lógica para elegir entre torretas normales o de ralentización
        Instantiate(normalTowerPrefab, towerPlace.transform.position, Quaternion.identity);
        towerPlaces[towerPlace] = true; // Marca la casilla como ocupada
    }
}
