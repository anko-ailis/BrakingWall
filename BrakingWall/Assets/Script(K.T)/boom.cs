using UnityEngine;

public class boom : MonoBehaviour
{
    // ”š”­

    private void PrivateMethod()
    {
        Debug.Log("PrivateMethod");
        Destroy(this.gameObject);
    }

    public void PublicMethod()
    {
        Debug.Log("PublicMethod");
    }
}
