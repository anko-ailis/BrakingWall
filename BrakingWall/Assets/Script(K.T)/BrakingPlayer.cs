using UnityEngine;

public class BrakingPlayer : MonoBehaviour
{
    //ï«Ç…ìñÇΩÇ¡ÇΩÇÁâÛÇÍÇÈ
    [SerializeField] private string tagEnamy;
    [SerializeField] private string tagColor;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.parent.gameObject.CompareTag(tagEnamy))
        {
            Debug.Log("-_-");
            Destroy(this.gameObject);
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
    //îöïóÇ…ìñÇΩÇ¡ÇΩÇÁè¡Ç¶ÇÈ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagEnamy))
        {
            Destroy(this.gameObject);
        }
        Debug.Log(collision.gameObject.tag);
    }
}
