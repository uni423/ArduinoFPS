using UnityEngine;

public class RabbitMoveHandle : StateHandle
{
    Transform cachedTransofrm;

    float curTime = 0f;
    float maxTime = 10f;


    /// <summary>
    /// 
    /// </summary>
    public override void OnEnter()
    {
        cachedTransofrm = parent.unitObject.transform;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delta"></param>
    public override void OnUpdate(float delta)
    {
        cachedTransofrm.position += cachedTransofrm.forward * delta * 5f;

        curTime += delta; 
        if (curTime >= maxTime)
            parent.ChangeFSMState(StateMachine.State.DeSpawn);
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
