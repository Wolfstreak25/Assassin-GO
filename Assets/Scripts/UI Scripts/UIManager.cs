using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    [SerializeField]    private GameObject m_levelEndUI;
    [SerializeField]    private TextMeshProUGUI m_levelStatusText;
    [SerializeField]    private GameObject m_nextLevelButton;
    public void LevelEndUI()
    {
        m_levelStatusText.text = $"{"Level Complete"}";
        m_levelEndUI.SetActive(true);
        m_nextLevelButton.SetActive(true);
    }
    public void PlayerDeathUI()
    {
        m_levelStatusText.text = $"{"Player Died"}";
        m_levelEndUI.SetActive(true);
        m_nextLevelButton.SetActive(false);
    }
}
