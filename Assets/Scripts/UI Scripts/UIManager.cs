using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    [SerializeField]    private GameObject m_levelEndUI;
    [SerializeField]    private TextMeshProUGUI m_levelStatusText;
    public void LevelEndUI()
    {
        m_levelStatusText.text = $"{"Level Complete"}";
        m_levelEndUI.SetActive(true);
    }
    public void PlayerDeathUI()
    {
        m_levelStatusText.text = $"{"Player Died"}";
        m_levelEndUI.SetActive(true);
    }
}
