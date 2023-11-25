using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnRefreshUI();
public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;
    public static UIManager Instance
    {
        get
        {
            if (m_instance != null) { return m_instance; }

            m_instance = FindObjectOfType<UIManager>();

            if (m_instance == null) { m_instance = new GameObject(name: "UIManager").AddComponent<UIManager>(); }
            return m_instance;
        }
    }

    public event OnRefreshUI onRefreshUserInfoUI;


    public void Init()
    {

    }
}
