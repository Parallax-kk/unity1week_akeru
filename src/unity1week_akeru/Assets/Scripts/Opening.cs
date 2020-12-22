using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AudioManager;
using DG.Tweening;
using Fungus;

public class Opening : MonoBehaviour
{
    /// <summary>
    /// 会話スタート用レシーバー
    /// </summary>
    [SerializeField]
    private MessageReceived m_OpeningMeeesageReceived = null;

    private void Start()
    {
        BGMManager.Instance.Play(BGMPath.OPENING, 1.0f, 0.0f, 1.0f, true);

        Sequence seq = DOTween.Sequence();
        Transition.Clear(seq);

        seq.AppendCallback(() => 
        {
            m_OpeningMeeesageReceived.OnSendFungusMessage("OpeningStart");
        });
    }

    /// <summary>
    /// 次のシーンへ遷移
    /// </summary>
    public void NextScene()
    {
        BGMManager.Instance.FadeOut(Transition.GetDuration());
        Transition.Black("Menu");
    }
}
