using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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
    private float lifeCount = 3;
    public float playerHelseCounter { 
        get { return lifeCount; }
        set { lifeCount = value; } }//getが受け取り、setが送り
    
    //public float helseCountreGetSet {  get;  set; }//getが贈る、setが受け取り
    void Start()
    {

        //lifeText.text = playerHelseCounter.ToString();
        lifeText.text = helseImage.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lifeCount = 3;
            LifeCounterManegre();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            lifeCount = 1;
            LifeCounterManegre();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(lifeCount + "ABC");
        }
        LifeCounterManegre();
        lifeText.text = lifeCount.ToString();
    }

    private void LifeCounterManegre()
    {
        //HPに応じてHPのUIの表示、非表示にする
        for (int i = 0; i < helseImage.Length; i++)
        {
            if (lifeCount > i)
            {
                Debug.Log(lifeCount + "/" + helseImage[i]);
                helseImage[i].SetActive(true);
            }
            else helseImage[i].SetActive(false);
        }
        Debug.Log(lifeCount+"123");
        //対応した画像を非表示にしてカウントを減らす
        //lifeArray[helseCounter - 1].SetActive(false);
        //HPが0になったらプレイヤーを消す
        if (lifeCount <= 0)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }
        //Debug.Log(helseCounter);
    }
}
