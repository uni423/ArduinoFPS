using UnityEngine;

public class RabbitSpawnHandle : StateHandle
{
    RabbitUnitObject unitObject;
    /// <summary>
    /// 
    /// </summary>
    public override void OnEnter()
    {
        Debug.LogError("�䳢 ����");
        unitObject = parent.unitObject as RabbitUnitObject;
        unitObject.audioSource.clip = unitObject.spawnSFX[Random.Range(0, unitObject.spawnSFX.Length)];
        unitObject.audioSource.Play();
    }
    float time = 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delta"></param>
    public override void OnUpdate(float delta)
    {
        time += delta;
        if (time >= 1f)
            parent.ChangeFSMState(StateMachine.State.Move);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lateDelta"></param>
    public override void OnLateUpdate(float lateDelta)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public override void OnExit()
    {
    }
}
