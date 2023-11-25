using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI : UIBase
{


    public override void Init()
    {
        base.Init();

        UIManager.Instance.onRefreshUserInfoUI += RefreshBulletInfo;
        UIManager.Instance.onRefreshUserInfoUI += RefreshScoreInfo;
        RefreshBulletInfo();
        RefreshScoreInfo();
    }

    private void RefreshScoreInfo()
    {

    }

    private void RefreshBulletInfo()
    {
    }
}
