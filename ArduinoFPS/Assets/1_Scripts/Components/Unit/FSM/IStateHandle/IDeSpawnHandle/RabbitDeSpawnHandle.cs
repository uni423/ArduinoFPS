using UnityEngine;

public class RabbitDeSpawnHandle : StateHandle
{
    /// <summary>
    /// 
    /// </summary>
    public override void OnEnter()
    {
        Debug.LogError("Åä³¢ ½ºÆù");
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
