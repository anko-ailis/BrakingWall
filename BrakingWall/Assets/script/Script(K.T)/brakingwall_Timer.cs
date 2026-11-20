using UnityEngine;

public class brakingwallTimer : MonoBehaviour
{
    //•Ç‚É“–‚½‚Á‚½‚ç‰ó‚ê‚é
    [SerializeField] private string tagName;
    private void Update()
    {
        if (5 < Mathf.Floor(Time.time / 10))
        {

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(5 < Mathf.Floor(Time.time/10))
        {

        }
        if(collision.gameObject.CompareTag(tagName))
        {
            Destroy(this.gameObject);
        }
        Debug.Log(collision.gameObject.tag);
        //collision.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            Destroy(this.gameObject);
        }
        Debug.Log(collision.gameObject.tag);
    }
}
