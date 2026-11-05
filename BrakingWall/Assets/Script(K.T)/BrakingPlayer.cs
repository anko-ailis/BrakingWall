using NUnit.Framework.Internal.Filters;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class BrakingPlayer : MonoBehaviour
{
    //壁に当たったら壊れる
    [SerializeField] private string tagEnamy;
    [Tooltip("対応したテキストを入れてください")]
    [SerializeField] private TextMeshProUGUI textMesh;  //時間表示のためのテキスト
    private int helseCounter = 3;
    private void Start()
    {
        textMesh.text = helseCounter.ToString();
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            helseCounter -=1;
            textMesh.text = helseCounter.ToString();
            if(helseCounter <= 0) 
            {
                Destroy(this.gameObject);
            }
            Debug.Log(helseCounter);
        }
        Debug.Log(collision.gameObject.tag);
    }
}
