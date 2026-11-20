using UnityEngine;
using UnityEngine.UI;

public class  UIChange : MonoBehaviour
{
    [SerializeField] private Image grabImage;  // grabImage
    //[SerializeField] private Image heartImage1; // heartImage1
    //[SerializeField] private Image heartImage2; // heartImage2
    //[SerializeField] private Image heartImage3; // heartImage3
    [SerializeField] private Sprite Sprite_Stage1;   // Stage1‚Ì‰æ‘œ
    [SerializeField] private Sprite Sprite_Stage2;   // Stage2‚Ì‰æ‘œ

    public void ChangeImage1()
    {
        // Stage1‚Ì‰æ‘œ‚É·‚µ‘Ö‚¦‚é
        grabImage.sprite = Sprite_Stage1;
    }
    public void ChangeImage2()
    {
        // Stage1‚Ì‰æ‘œ‚É·‚µ‘Ö‚¦‚é
        grabImage.sprite = Sprite_Stage2;
    }

}