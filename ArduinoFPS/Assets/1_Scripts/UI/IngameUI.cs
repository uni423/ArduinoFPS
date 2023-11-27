using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : UIBase
{
    public Image[] bulletImage;
    public Color bulletOnColor;
    public Color bulletOffColor;
    public Text scoreText;
    public Text timeText;

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
        scoreText.text = string.Concat("Score: " + InGameManager.Instance.score);
    }

    private void RefreshBulletInfo()
    {
        for (int i = 0; i < InGameManager.Instance.playerControl.bulletCountMax; i++)
        {
            bulletImage[i].color = (i < InGameManager.Instance.playerControl.bulletCountCur) ? bulletOnColor : bulletOffColor;
        }
    }

    public void Update()
    {
        timeText.text = string.Concat(InGameManager.Instance.gameTime.ToString("N0"), "s");
    }
}
