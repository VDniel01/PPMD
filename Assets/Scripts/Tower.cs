using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fireCooldown = 1f;
    private float fireCooldownLeft = 0f;

    void Update()
    {
        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0f)
        {
            // L�gica de disparo
            GameObject target = FindTarget(); // M�todo para encontrar un objetivo (necesitas implementarlo)
            if (target != null)
            {
                Attack(target.transform); // Cambiar a target.transform
            }
        }
    }

    protected virtual void Attack(Transform target)
    {
        // Crear bala y establecer su objetivo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetTarget(target);
        }
        fireCooldownLeft = fireCooldown;
    }

    private GameObject FindTarget()
    {
        // Implementar la l�gica para encontrar un objetivo cercano
        return null;
    }
}
