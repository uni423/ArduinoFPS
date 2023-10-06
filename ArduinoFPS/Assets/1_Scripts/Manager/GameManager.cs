using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static ObjectPooling ObjectPooling { get; private set; }


    protected void Awake()
    {
        Instance = this;

        ObjectPooling = FindObjectOfType<ObjectPooling>();
    }
}
