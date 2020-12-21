using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Transition.Black();
    }
}
