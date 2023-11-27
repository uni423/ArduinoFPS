using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitUnit : Unit
{
    RabbitUnitObject unitObject;

    public override void Initialize()
    {
        base.Initialize();

        unitObject = InGameManager.ObjectPooling.Spawn<RabbitUnitObject>(this.unitData.model);
        //unitObject.model.transform.localPosition = Vector3.zero;
        //unitObject.model.transform.localRotation = Quaternion.identity;
        base.unitObject = unitObject;
        unitObject.LoadModel("");

        unitObject.SetAgent(this);
        unitObject.SetController();

        stateMachine = new StateMachine();
        stateMachine.Initialize();
        stateMachine.Regist(StateMachine.State.Spawn, new StateSpawn(this));
        stateMachine.Regist(StateMachine.State.Move, new StateMove(this));
        stateMachine.Regist(StateMachine.State.Hit, new StateHit(this));
        stateMachine.Regist(StateMachine.State.Death, new StateDeath(this));
        stateMachine.Regist(StateMachine.State.DeSpawn, new StateDeSpawn(this));

        SetStat();
        RegistHandler();
    }

    public override void RegistHandler()
    {
        SetHandle(StateMachine.State.Spawn, StateHandleFactory.Create<RabbitSpawnHandle>());
        SetHandle(StateMachine.State.Move, StateHandleFactory.Create<RabbitMoveHandle>());
        SetHandle(StateMachine.State.Hit, StateHandleFactory.Create<RabbitHitHandle>());
        SetHandle(StateMachine.State.Death, StateHandleFactory.Create<RabbitDeathHandle>());
        SetHandle(StateMachine.State.DeSpawn, StateHandleFactory.Create<RabbitDeSpawnHandle>());
    }


    public void Hit(AttackType type)
    {
        if (IsDeath == true)
            return;

        switch (type)
        {
            case AttackType.Normal:
                hp -= 10;
                //ChangeFSMState(StateMachine.State.Hit);
                CheckDead();
                break;
        }
    }

    public void CheckDead()
    {
        if (hp > 0 || IsDeath == true)
            return;

        ChangeFSMState(StateMachine.State.Death);
    }

}
