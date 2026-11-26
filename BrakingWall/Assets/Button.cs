using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Scene scene;
    public void StartGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene("Ryouga");
    }
}