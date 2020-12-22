using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    private static MasterData m_Instance = null;

    /// <summary>
    /// 残り日数
    /// </summary>
    private static int m_RemainingDays = 10;
    public static int GetRemainingDays() { return m_RemainingDays; }

    /// <summary>
    /// 所持金
    /// </summary>
    private static int m_Money = 0;
    public static void AddMoney(int value) { m_Money += value; }
    public static int GetMoney() { return m_Money; }

    /// <summary>
    /// 獲得したヒーロー
    /// </summary>
    private static Dictionary<int, bool> m_dicGetHero = new Dictionary<int, bool>();
    public static void AddHero(int id) { m_dicGetHero[id] = true; }

    private void Awake()
    {
        CheckInstance();
    }

    private bool CheckInstance()
    {
        if (m_Instance == null)
        {
            m_Instance = (MasterData)this;
            return true;
        }
        else if (m_Instance == this)
        {
            return true;
        }

        Destroy(this);
        return false;
    }
}
