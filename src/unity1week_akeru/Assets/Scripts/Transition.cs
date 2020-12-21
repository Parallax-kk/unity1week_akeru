using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class Transition : MonoBehaviour
{
    /// <summary>
    /// フェード時間
    /// </summary>
    private static float m_FadeDuration = 2.0f;

    /// <summary>
    /// フェード画像
    /// </summary>
    private static Image m_FadeImage = null;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        m_FadeImage = GameObject.Find("TransitionCanvas/Image").GetComponent<Image>();
    }

    /// <summary>
    /// 黒
    /// </summary>
    public static void Black(string sceneName = "")
    {
        Sequence seq = DOTween.Sequence();
        seq.Join(m_FadeImage.DOFade(1.0f, m_FadeDuration));

        if (!string.IsNullOrEmpty(sceneName))
        {
            seq.AppendCallback(() => 
            {
                SceneManager.LoadScene(sceneName);
            });
        }
    }

    /// <summary>
    /// クリア
    /// </summary>
    public static void Clear (string sceneName = "")
    {
        Sequence seq = DOTween.Sequence();
        seq.Join(m_FadeImage.DOFade(0.0f, m_FadeDuration));

        if (!string.IsNullOrEmpty(sceneName))
        {
            seq.AppendCallback(() =>
            {
                SceneManager.LoadScene(sceneName);
            });
        }
    }
}
