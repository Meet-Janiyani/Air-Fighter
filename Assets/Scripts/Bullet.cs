using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    void FixedUpdate()
    {
        transform.Translate(bulletSpeed * Vector2.right);

        if(transform.position.x > 10)
        {
            gameObject.SetActive(false);
        }
    }
}
