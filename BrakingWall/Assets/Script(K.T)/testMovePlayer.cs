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
     
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
    }
}
