using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject towerPrefab;
    public int cost;
    private Transform canvasTransform;
    private GameObject draggingObject;

    void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingObject = Instantiate(towerPrefab, canvasTransform);
        draggingObject.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingObject != null)
        {
            draggingObject.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggingObject != null)
        {
            Destroy(draggingObject);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("TowerPlace"))
            {
                GameObject tower = Instantiate(towerPrefab, hit.collider.transform.position, Quaternion.identity);
                hit.collider.gameObject.GetComponent<TowerPlace>().PlaceTower(tower);
            }
        }
    }
}
