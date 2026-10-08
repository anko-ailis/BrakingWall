using UnityEngine;
using TMPro;

public class moveText : MonoBehaviour
{
    [SerializeField] private GameObject target; // 追従対象
    [SerializeField] private Vector3 offset; // オフセット
    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {

        if (target != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position + offset);
            rectTransform.position = screenPos ; // スクリーン座標に変換してUI位置を更新
        }
        if(target == null)
        {
            Destroy(this.gameObject);
        }
        //float timeFloor = Mathf.Floor(Time.time);
        //textMesh.text = (10 - timeFloor).ToString(); 
    }
}
