using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float clampValue = 3.6f;
    [SerializeField] BulletPoolManager poolManager;
    [SerializeField] Transform firePoint;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Movement();
        RestrictMovement();
        Fire();

    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void RestrictMovement()
    {
        Vector2 currentPosition = transform.position;
        float clampedy = Mathf.Clamp(currentPosition.y, -clampValue, clampValue);
        rb.position = new Vector2(currentPosition.x, clampedy);
    }

    private void Movement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(0, verticalInput * movementSpeed);
    }

    private void Shoot()
    {
        GameObject bullet = poolManager.getBullet();
        if (bullet != null)
        {
            bullet.transform.position =firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
