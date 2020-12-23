using UnityEngine;
using UnityEngine.UI;

public class Wreath : MonoBehaviour
{
    /// <summary>
    /// 金額
    /// </summary>
    [SerializeField]
    private int m_Money = 0;
    public int  GetMoney(         ) { return m_Money;  }
    public void SetMoney(int money) { m_Money = money; }

    /// <summary>
    /// 穴が開いているか否か
    /// </summary>
    [SerializeField]
    private bool m_isHole = false;
    public void AddHole  () { m_isHole = true; }
    public bool GetIsHole() { return m_isHole; }

    /// <summary>
    /// スプライトレンダラー
    /// </summary>
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer = null;
    public void SetSprite(Sprite sprite) { m_SpriteRenderer.sprite = sprite; }
}
