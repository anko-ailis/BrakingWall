using NUnit.Framework.Internal.Filters;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class BrakingPlayer : MonoBehaviour
{
    //壁に当たったら壊れる
    [SerializeField] private string tagEnamy;
    [Tooltip("HP")]
    [SerializeField] private TextMeshProUGUI lifeText;  //時間表示のためのテキスト
    [SerializeField] private Image[] lifeImage;
    [SerializeField] private Sprite lostLife;
    private int helseCounter = 3;
    private int lifeCount;
    private void Start()
    {
        lifeCount = lifeImage.Length;
        lifeText.text = helseCounter.ToString();
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
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //エネミータグにあたると死ぬ
        if(collision.gameObject .transform.parent != null)
        {
            if (collision.gameObject.transform.parent.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("-_-");
                Destroy(this.gameObject);
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
            Destroy(this.gameObject);
            helseCounter -=1;
            lifeText.text = helseCounter.ToString();
            if(helseCounter <= 0) 
            {
                Destroy(this.gameObject);
            }
            Debug.Log(helseCounter);
        }
        Debug.Log(collision.gameObject.tag);
    }
}
