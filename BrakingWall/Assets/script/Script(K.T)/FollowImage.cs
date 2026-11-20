using UnityEngine;


public class FollowImage : MonoBehaviour
{
    [SerializeField] private GameObject target; // 追従対象
    [SerializeField] private Vector3 offset; // ターゲットとの相対位置
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position + offset);
        this.transform.position =(target.transform.position + offset);
    }
}
