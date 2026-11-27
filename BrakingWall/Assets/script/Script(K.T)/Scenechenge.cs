using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //これ必須です

public class Scene : MonoBehaviour
{

    [SerializeField] private string _loadScene; //シーン名を記述
    [SerializeField]private string _goalScene;
    public void SceneChange()
    {
        Debug.Log("asdw");
        SceneManager.LoadScene(_loadScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            SceneManager.LoadScene(_goalScene);
        }
    }
}