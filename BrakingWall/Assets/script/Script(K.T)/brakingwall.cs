using UnityEngine;

public class brakingwall : MonoBehaviour
{
    //•Ç‚É“–‚½‚Á‚½‚ç‰ó‚ê‚é
    [SerializeField] private string tagName;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(tagName))
        {
            Destroy(this.gameObject);
        }
        //Debug.Log(collision.gameObject.tag);
        //collision.gameObject;
    }
}
