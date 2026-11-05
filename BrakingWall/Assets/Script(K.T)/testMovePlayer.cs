using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class testMovePlayer : MonoBehaviour
{
    [SerializeField]private float speed;
    // Update is called once per frame

    private void Start()
    {
        Application.targetFrameRate = 60;
        if (speed == 0)
        {
            speed = 1;
        }
    }
    void Update()
    {
     
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Delete)) Destroy(this.gameObject);
    }
}
