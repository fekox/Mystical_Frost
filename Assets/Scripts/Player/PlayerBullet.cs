using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody rigidbody;
    
    [SerializeField] private float bulletLifeTime;

    private float maxTime;

    void Start()
    {
        maxTime = bulletLifeTime;

        rigidbody.velocity = transform.right * speed;
    }

    private void Update()
    {
        DestroyBulletLogic();
    }

    public void DestroyBulletLogic() 
    {
        maxTime -= Time.deltaTime;

        if (maxTime <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
