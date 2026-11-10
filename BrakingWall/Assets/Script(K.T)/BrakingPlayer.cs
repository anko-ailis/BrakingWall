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
    private void Start()
    {
        //lifeCount = lifeImage.Length;
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
            lifeArray[helseCounter - 1].SetActive(false);
            helseCounter--;
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
