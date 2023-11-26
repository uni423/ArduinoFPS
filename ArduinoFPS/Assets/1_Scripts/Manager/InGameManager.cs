using Microsoft.Win32;
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

    public PlayerControl playerControl;

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

            Vector3 getPoint = Random.onUnitSphere;
            getPoint.y = 0.0f;

            float radius = 10f;
            float r = Random.Range(0.0f, radius);
            rabbit.unitObject.cachedTransform.position = (getPoint * r) + playerControl.transform.position;

            rabbit.unitObject.cachedTransform.rotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);

            unitManager.Regist(rabbit);
        }

        unitManager.OnUpdate(Time.deltaTime);
    }

    private void LateUpdate()
    {
        unitManager.OnLateUpdate(Time.deltaTime);
    }
}
