using NUnit.Framework.Internal.Filters;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class BrakingPlayer : MonoBehaviour
{
    //壁に当たったら壊れる
    [SerializeField] private string tagEnamy;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        Debug.Log(collision.gameObject.tag);
    }
}
