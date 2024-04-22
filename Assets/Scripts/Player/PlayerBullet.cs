using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("SetUp")]
    [SerializeField] private float bulletSpeed = 50f;

    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private float bulletLifeTime = 4f;

    [SerializeField] private float maxBulletScale = 0.5f;

    private float maxBulletLifeTime;

    private bool canShoot = false;

    private void Start()
    {
        maxBulletLifeTime = bulletLifeTime;
    }

    private void Update()
    {
        rigidBody.velocity = transform.right * bulletSpeed;
      
        DestroyBullet();
    }

    public void DestroyBullet() 
    {
        maxBulletLifeTime -= Time.deltaTime;

        if (maxBulletLifeTime <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public void SetCanShoot(bool newCanShoot) 
    {
        newCanShoot = canShoot;
    }

    public void IncreaseShootSize()
    {
        Vector3 newScale = new Vector3(0, 0, 0);

        newScale.x = Mathf.Clamp(newScale.x, 0, maxBulletScale);
        newScale.y = Mathf.Clamp(newScale.y, 0, maxBulletScale);
        newScale.z = Mathf.Clamp(newScale.z, 0, maxBulletScale);

        transform.localScale = newScale;
    }
}
