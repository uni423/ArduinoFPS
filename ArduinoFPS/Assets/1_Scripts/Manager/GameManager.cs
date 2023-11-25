using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public BluetoothManager bluetoothManager;
    public InGameManager inGameManager;

    public GameStep gameStep;

    protected void Awake()
    {
        Instance = this;

        StartCoroutineMethod(TableBase.LoadAllDataTable());

        //bluetoothManager.Init();

        //추후 씬을 나눌 경우 해당 Init을 Awake로 변경.
        inGameManager.Init();
    }

    #region Coroutine
    public static Coroutine StartCoroutineMethod(IEnumerator enumerator)
    {
        return Instance.StartCoroutine(enumerator);
    }

    public static void StopCoroutineMethod(string name)
    {
        Instance.StopCoroutine(name);
    }

    public static void StopAllCoroutineMethod()
    {
        Instance.StopAllCoroutines();
    }
    #endregion
}
