using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : UIBase
{
    public Text scoreText;

    public override void ShowUI()
    {
        base.ShowUI();
        scoreText.text = string.Concat("Score: " + InGameManager.Instance.score);
    }

    public void OnClick_ReStart()
    {
        SceneLoader.Load("GameScene");
    }

    public void OnClick_MainMenu()
    {
        SceneLoader.Load("MainScene");
    }
}
