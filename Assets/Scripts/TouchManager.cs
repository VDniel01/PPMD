using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject normalTowerPrefab;
    public GameObject slowTowerPrefab;
    public Transform towersParent; // Un contenedor para todas las torres
    private GameObject selectedTowerPrefab;
    private GameObject draggingTower;
    private bool isDragging = false;

    void Start()
    {
        selectedTowerPrefab = normalTowerPrefab; // Inicialmente seleccionamos la torre normal
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTouchBegin(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            OnTouchMove(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            OnTouchEnd(Input.mousePosition);
        }
    }

    void OnTouchBegin(Vector3 touchPosition)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; // Si se está tocando la UI, no hagas nada
        }

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        worldPosition.z = 0;

        if (selectedTowerPrefab != null)
        {
            draggingTower = Instantiate(selectedTowerPrefab, worldPosition, Quaternion.identity, towersParent);
            isDragging = true;
        }
    }

    void OnTouchMove(Vector3 touchPosition)
    {
        if (draggingTower != null)
        {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            worldPosition.z = 0;
            draggingTower.transform.position = worldPosition;
        }
    }

    void OnTouchEnd(Vector3 touchPosition)
    {
        if (draggingTower != null)
        {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            worldPosition.z = 0;

            GameObject hitObject = GetHitObject(worldPosition);
            if (hitObject != null && hitObject.CompareTag("TowerPlace") && hitObject.transform.childCount == 0)
            {
                draggingTower.transform.position = hitObject.transform.position;
            }
            else
            {
                Destroy(draggingTower);
            }

            draggingTower = null;
            isDragging = false;
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

    public void SelectNormalTower()
    {
        selectedTowerPrefab = normalTowerPrefab;
    }

    public void SelectSlowTower()
    {
        selectedTowerPrefab = slowTowerPrefab;
    }
}
