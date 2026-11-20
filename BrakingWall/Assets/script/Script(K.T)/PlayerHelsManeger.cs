using TMPro;
using UnityEngine;

public class PlayerHelsManeger : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのHP管理。プレイヤーで管理させていたものをこっちに移動する
    /// </summary>
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Tooltip("HP画像（image）")]
    [SerializeField] private GameObject[] helseImage;       //プレイヤーのHP画像
    [Tooltip("HP　")]
    [SerializeField] private TextMeshProUGUI lifeText;  //HP表示のためのテキスト　目安のため残してある後で消す
    private float playerHelseCounter = 3;
    void Start()
    {
        lifeText.text = playerHelseCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LifeCounterManegre()
    {
        //HPに応じてHPのUIの表示、非表示にする
        for (int i = 0; i < helseImage.Length; i++)
        {
            if (playerHelseCounter > i)
            {

                Debug.Log(playerHelseCounter + "/" + helseImage[i]);
                helseImage[i].SetActive(true);
            }
            else helseImage[i].SetActive(false);
        }
        //対応した画像を非表示にしてカウントを減らす
        //lifeArray[helseCounter - 1].SetActive(false);
        lifeText.text = playerHelseCounter.ToString();
        //HPが0になったらプレイヤーを消す
        if (playerHelseCounter <= 0)
        {
            Destroy(this.gameObject);
        }
        //Debug.Log(helseCounter);
    }
}
