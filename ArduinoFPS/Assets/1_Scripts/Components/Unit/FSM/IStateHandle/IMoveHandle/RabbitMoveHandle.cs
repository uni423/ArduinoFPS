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
        cachedTransofrm = parent.unitObject.cachedTransform;
        
        parent.SetAnimationParam("IsMove", true);
        int special = Random.Range(0, 20);
        if (special == 0)
            parent.SetAnimationParam("MoveType", 1);
        else if (special == 1)
            parent.SetAnimationParam("MoveType", 2);
        else if (special == 2)
            parent.SetAnimationParam("MoveType", 3);
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
