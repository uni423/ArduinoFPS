using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public Transform cachedTransform;

    void Start()
    {
        cachedTransform = this.transform;


    }
    
    void Update()
    {
        cachedTransform.position += transform.forward * speed * Time.deltaTime;
    }
}
