using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using AudioManager;

public class Title : MonoBehaviour
{
    /// <summary>
    /// プレゼントのスプライト
    /// </summary>
    [SerializeField]
    private List<Sprite> m_listPresentSprites = new List<Sprite>();

    /// <summary>
    /// プレゼント生成
    /// </summary>
    [SerializeField]
    private GameObject m_PresentSpowner = null;

    /// <summary>
    /// プレゼントのプレハブ
    /// </summary>
    [SerializeField]
    private GameObject m_PresentPrefab = null;

    /// <summary>
    /// スタートボタン
    /// </summary>
    [SerializeField]
    private Button m_StartButton = null;

    private void Awake()
    {
        BGMManager.Instance.Play(BGMPath.TITLE, 1.0f, 0.0f, 1.0f, true);
        StartCoroutine("CreatePresent");
    }

    IEnumerator CreatePresent()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(0, 10); i++)
            {
                GameObject present = Instantiate(m_PresentPrefab, new Vector3(Random.Range(-7.0f, 7.0f), m_PresentSpowner.transform.position.y + Random.Range(0, 7.0f), 0.0f), Quaternion.identity, m_PresentSpowner.transform);
                present.GetComponent<Rigidbody>().AddTorque(new Vector3(0.0f,0.0f, Random.Range(-20.0f, 20.0f)));
                present.GetComponent<SpriteRenderer>().sprite = m_listPresentSprites[Random.Range(0, m_listPresentSprites.Count)];
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void ClickStartButton()
    {
        m_StartButton.interactable = false;
        BGMManager.Instance.FadeOut(Transition.GetDuration());

        Transition.Black("Opening");
    }
}
