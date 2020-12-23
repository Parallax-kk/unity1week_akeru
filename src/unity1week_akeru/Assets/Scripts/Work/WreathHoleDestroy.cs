using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreathHoleDestroy : MonoBehaviour
{
    [SerializeField]
    private Work_WreathHole m_Work_WreathHole = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int money = collision.gameObject.GetComponent<Wreath>().GetMoney();
        MasterData.AddMoney(money);
        m_Work_WreathHole.UpdateMoneyText();
        Destroy(collision.gameObject);
    }
}
