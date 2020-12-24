using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AudioManager;
using TMPro;

public class Work_WreathHole : MonoBehaviour
{
    /// <summary>
    /// 金額テキスト
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI m_MoneyText = null;
    public void UpdateMoneyText() { m_MoneyText.text = string.Format("{0:#,0} 円", MasterData.GetMoney().ToString()); }

    /// <summary>
    /// ベルトのレンダラー
    /// </summary>
    [SerializeField]
    private Renderer m_BeltRenderer = null;

    /// <summary>
    /// リース生成ポイント
    /// </summary>
    [SerializeField]
    private GameObject m_WreathSpownPoint = null;

    /// <summary>
    /// レースPrefab
    /// </summary>
    [SerializeField]
    private GameObject m_WreathPrefab = null;

    /// <summary>
    /// レースSprite
    /// </summary>
    [SerializeField]
    private List<Sprite> m_listWreathSprites = new List<Sprite>();

    /// <summary>
    /// ベルトスピード
    /// </summary>
    [SerializeField]
    private float m_BeltSpeed = 5.0f;

    /// <summary>
    /// ベルトスピード係数
    /// </summary>
    [SerializeField]
    private float m_BeltSpeedCoefficient = 1.0f;

    /// <summary>
    /// ベルトアニメーションスピード
    /// </summary>
    [SerializeField]
    private float m_BeltAnimSpeed = 0.1f;

    /// <summary>
    /// レース生成スピード
    /// </summary>
    [SerializeField]
    private float m_WreathInstantiateSpeed = 3.0f;

    /// <summary>
    /// レース生成スピード係数
    /// </summary>
    [SerializeField]
    private float m_WreathInstatiateSpeedCoefficient = 1.0f;

    private void Awake()
    {
        m_MoneyText.text = string.Format("{0:#,0} 円", MasterData.GetMoney().ToString());

        m_BeltSpeedCoefficient = MasterData.GetBeltAnimSpeedCoefficient();
        m_WreathInstatiateSpeedCoefficient = MasterData.GetWreathInstatiateSpeedCoefficient();
    }

    private void Start()
    {
        BGMManager.Instance.Play(BGMPath.WORKING, 1.0f, 0.0f, 1.0f, true);
        Transition.Clear();
        StartCoroutine("CreateWreath");
    }

    /// <summary>
    /// レース生成
    /// </summary>
    /// <returns></returns>
    IEnumerator CreateWreath()
    {
        while (true)
        {
            Instantiate(m_WreathPrefab, m_WreathSpownPoint.transform);
            yield return new WaitForSeconds(m_WreathInstantiateSpeed * m_WreathInstatiateSpeedCoefficient);
        }
    }

    private void Update()
    {
        MoveBelt();

        if(Input.GetMouseButtonDown(0))
        {
            AddHole();
        }
    }

    /// <summary>
    /// ベルトコンベアのアニメーション
    /// </summary>
    private void MoveBelt()
    {
        float scroll = Mathf.Repeat(Time.time * -m_BeltAnimSpeed * m_BeltSpeedCoefficient, 1);
        Vector2 offset = new Vector2(scroll, 0);
        m_BeltRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    /// <summary>
    /// レースに穴をあける
    /// </summary>
    private void AddHole()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider)
        {
            GameObject obj = hit.collider.gameObject;
            Debug.Log(hit.collider.gameObject.name);
            if (obj.layer == LayerMask.NameToLayer("Wreath"))
            {
                Wreath wreath = obj.GetComponent<Wreath>();
                if (!wreath.GetIsHole())
                {
                    SEManager.Instance.Play(SEPath.ADD_HOLE);

                    wreath.AddHole();

                    Transform hole = obj.transform.Find("Hole");
                    hole.position = hit.point;

                    // 成否判定
                    if(-0.2f < hole.localPosition.x && hole.localPosition.x < 0.2f &&
                       -0.2f < hole.localPosition.y && hole.localPosition.y < 0.2f )
                    {
                        Debug.Log("成功");
                        wreath.SetSprite(m_listWreathSprites[0]);
                        wreath.SetMoney(50);
                    }
                    else
                    {
                        hole.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (m_BeltSpeed * m_BeltSpeedCoefficient, 0.0f);
    }

    /// <summary>
    /// バイトを終わるボタン
    /// </summary>
    public void ClickMenuBotton()
    {
        BGMManager.Instance.FadeOut(Transition.GetDuration());
        Transition.Black("Menu");
    }
}
