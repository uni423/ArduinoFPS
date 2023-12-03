using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongRbUnitObject : RabbitUnitObject
{
    StrongRbUnit rabbit;

    public override void SetAgent(Unit _unit)
    {
        base.SetAgent(_unit);

        rabbit = unit as StrongRbUnit;
    }
}
