using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public UnitManager unitManager { private set; get; }

    public static ObjectPooling ObjectPooling { get; private set; }

    public static bool IsPlaying;
    public static bool IsContinue;
    public static bool IsReSetting;

    private float time;

    //protected void Awake()
    public void Init()
    {
        Instance = this;

        ObjectPooling = FindObjectOfType<ObjectPooling>();

        IsPlaying = false;
        IsContinue = false;
        IsReSetting = false;

        unitManager = new UnitManager();
        unitManager.Initialize();

        UIManager.Instance.Init();

        DoGameStart();
    }

    public static void DoGameStart()
    {
        GameManager.Instance.gameStep = GameStep.Playing;

        IsPlaying = true;
        IsReSetting = false;

    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 5f)
        {
            time -= 5f;

            RabbitUnit rabbit = new RabbitUnit();
            rabbit.SetUnitTable(201);
            rabbit.Initialize();
            rabbit.unitObject.cachedTransform.position = new Vector3(56.47726f, 1, -49.3681f);
        }
    }

}
