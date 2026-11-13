using NUnit.Framework.Internal.Filters;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class BrakingPlayer : MonoBehaviour
{
    //[SerializeField] private string tagEnamy;
    //[Tooltip("")]
    [SerializeField] private GameObject[] lifeArray;  //時間表示のためのテキスト
    [Tooltip("HP")]
    [SerializeField] private TextMeshProUGUI lifeText;  //時間表示のためのテキスト
    private int helseCounter = 3;
    private int lifeCount;
    ChekPoint Chek;
    Transform tratra;
    public Transform PlayerSpawPos
    {
        get {return tratra; }
        set {tratra = value;}
    }
    private void Start()
    {
        if (tratra == null) tratra = this.transform;
        this.transform.position = tratra.transform.position;
        //this.transform.position = Chek.VecSpawnPoint;
        //lifeCount = lifeImage.Length;
        lifeText.text = helseCounter.ToString();
        Debug.Log(tratra + "^^");
    }
    private void Update()
    {
        for(int i = 0; i > lifeCount; i--)
        {
            if (lifeCount > helseCounter)
            {
                //画像を入れ替える
                //lifeImage.[i] = lostLife;
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            helseCounter = 3;
            LifeCounterManegre();
        }
        if (Input.GetKey(KeyCode.T))
        {
            helseCounter = 1;
            LifeCounterManegre();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //エネミータグにあたると死ぬ
        if(collision.gameObject .transform.parent != null)
        {
            if (collision.gameObject.transform.parent.gameObject.CompareTag("Enemy"))
            {
                //helseCounter -= 1;
                //if (helseCounter < 1)
                //{
                //    Destroy(this.gameObject);
                //}
                Debug.Log("-_-");
            }
        }
        //foreach (GameObject enem in tagName)
        //{

        //}
        //if (collision.gameObject.CompareTag(tagName))
        //{
        //    
        //}
        //Debug.Log(collision.gameObject.tag);
        //collision.gameObject;
    }
    //爆風に当たったら消える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵に当たったらHPを減らす
        if (collision.gameObject.CompareTag("Enemy"))
        {
            helseCounter--;
            LifeCounterManegre();
        }
        //チェックポイントに触れたら座標を保存する
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            tratra = collision.transform;
        }
        Debug.Log(collision.gameObject.tag);
    }

    private void LifeCounterManegre()
    {
        //HPに応じてHPのUIの表示、非表示にする
        for (int i = 0; i <= lifeCount; i++)
        {
            if (helseCounter < i)
            {
                lifeArray[i].SetActive(true);
            }
            else lifeArray[i].SetActive(false);
        }
        //対応した画像を非表示にしてカウントを減らす
        //lifeArray[helseCounter - 1].SetActive(false);
        lifeText.text = helseCounter.ToString();
        //HPが0になったらプレイヤーを消す
        if (helseCounter <= 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(helseCounter);
    }
}
