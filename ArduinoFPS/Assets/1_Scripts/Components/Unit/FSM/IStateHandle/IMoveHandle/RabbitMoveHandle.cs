using UnityEngine;

public class RabbitMoveHandle : StateHandle
{
    Transform cachedTransofrm;
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
        cachedTransofrm.position += cachedTransofrm.forward * 0.3f;
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
