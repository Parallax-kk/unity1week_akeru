using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreathHoleDestroy : MonoBehaviour
{
    [SerializeField]
    private Work_WreathHole m_Work_WreathHole = null;

    [SerializeField]
    private float m_MoneyCoefficient = 1.0f;

    private void Awake()
    {
        m_MoneyCoefficient = MasterData.GetMoneyCoefficient();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int money = collision.gameObject.GetComponent<Wreath>().GetMoney();
        MasterData.AddMoney((int)(money * m_MoneyCoefficient));
        m_Work_WreathHole.UpdateMoneyText();
        Destroy(collision.gameObject);
    }
}
