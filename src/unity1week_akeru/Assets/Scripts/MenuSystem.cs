using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AudioManager;
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
        BGMManager.Instance.FadeOut(Transition.GetDuration());
        Transition.Black("Work_WreathHole");
    }

    /// <summary>
    /// ガチャボタン押したとき
    /// </summary>
    public void ClickGachaBotton()
    {

    }

    private void Start()
    {
        BGMManager.Instance.Play(BGMPath.MENU, 1.0f, 0.0f, 1.0f, true);
        m_DayText.text = "残り " + MasterData.GetRemainingDays() + " 日";
        m_MoneyText.text = MasterData.GetMoney().ToString();

        Transition.Clear();
    }
}
