using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class MenuSystem : MonoBehaviour
{
    /// <summary>
    /// 日数テキスト
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_DayText = null;

    /// <summary>
    /// お金テキスト
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_MoneyText = null;

    /// <summary>
    /// 仕事ボタン押したとき
    /// </summary>
    public void ClickWorkBotton()
    {

    }

    /// <summary>
    /// ガチャボタン押したとき
    /// </summary>
    public void ClickGachaBotton()
    {

    }

    private void Awake()
    {
        m_DayText.text = "残り " + MasterData.GetRemainingDays() + " 日";
        m_MoneyText.text = MasterData.GetMoney().ToString();
    }
}
