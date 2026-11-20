using UnityEngine;
using UnityEngine.UI;

public class SliderExample : MonoBehaviour
{
    [SerializeField] Slider sutaminaSlider; // スライダー UI の参照
    private float maxsutamina = 100; // スタミナの最大値
    private float currentsutamina; // 現在のスタミナ
    private bool thereissutamina; // スタミナがあるかどうかの判定

    void Start()
    {
        currentsutamina = maxsutamina; // ゲーム開始時に現在のスタミナを最大値に設定
        sutaminaSlider.maxValue = maxsutamina; // スライダーの最大値を設定
        sutaminaSlider.value = currentsutamina; // スライダーの初期値を現在のスタミナに設定
    }
    void Update()
    {
        currentsutamina += 5 * Time.deltaTime; // スタミナを徐々に回復
        sutaminaSlider.value = currentsutamina; // スライダー UI に反映
    }
    public bool IsStaminaAvailable()
    {
        if (currentsutamina >= 100)// スタミナが足りている場合
        {
            currentsutamina -= 100; // スタミナを減少
            thereissutamina = true; // スタミナがあることを示す
        }
        else
        {
            thereissutamina = false; // スタミナが不足していることを示す
        }
        return thereissutamina; // スタミナが足りてるかかどうかを返す
    }
}