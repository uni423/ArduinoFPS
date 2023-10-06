using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    Transform cachedTransform;
    bool isCollisioin;

    void Start()
    {
        cachedTransform = this.transform;
    }

    public void OnEnable()
    {
        isCollisioin = false;
    }

    void Update()
    {
        if (!isCollisioin)
            cachedTransform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollisioin = true;
    }
}
