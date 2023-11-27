using UnityEngine;

public class RabbitDeathHandle : StateHandle
{
    RabbitUnit unit;
    float time = 0;
    /// <summary>
    /// 
    /// </summary>
    public override void OnEnter()
    {
        unit = parent as RabbitUnit;
        unit.IsDeath = true;
        unit.SetAnimationParam("IsDeath", true);
        unit.SetAnimationParam("IsSpawn", false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delta"></param>
    public override void OnUpdate(float delta)
    {
        time += delta;
        if (time >= 3f)
        {
            InGameManager.ObjectPooling.Despawn(parent.unitObject.gameObject);
            InGameManager.Instance.AddScore(parent.unitData.point);
        }
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
