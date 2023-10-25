using UnityEngine;

public class StateSpawn : StateBase
{
    public StateSpawn(Unit parent) : base(parent) { state = StateMachine.State.Spawn; }

    string AnimationName = "Spawn";

    public override void Enter()
    {        
        parent.SetAnimationParam("IsSpawn", true);

    }

    public override void Update(float delta)
    {
        if (parent.unitObject.animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationName) &&
            parent.unitObject.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            parent.SetAnimationParam("IsSpawn", false);
            parent.ChangeFSMState(StateMachine.State.Move);
        }

        //if (handle == null)
        //    return;
        //handle.OnUpdate(delta);
    }
    
    public override void LateUpate(float latedDelta)
    {
        //if (handle == null)
        //    return;
        //handle.OnLateUpdate(latedDelta);
    }

    public override void Exit()
    {
        //handle.OnExit();
    }
    public override void HandleInput() { }    
}
