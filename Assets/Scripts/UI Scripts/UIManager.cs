using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]    private GameObject m_levelEndUI;
    public void LevelEndUI()
    {
        m_levelEndUI.SetActive(true);
    }
    public void PlayerDeathUI()
    {
        m_levelEndUI.SetActive(true);
    }
}
