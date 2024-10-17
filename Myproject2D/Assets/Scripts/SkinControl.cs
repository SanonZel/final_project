using UnityEngine;
using UnityEngine.UI;

public class SkinControl : MonoBehaviour
{
    public static int SelectedSkin;
    public int skinNum;
    public Button buyButton;
    public int price;

    private void Start()
    {
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>() + "buy") == 0)
        {
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>() + "buy") == 1) 
        {
            if (PlayerPrefs.GetInt(GetComponent<Image>() + "equip") == 1)
            {
            } 
            else if (PlayerPrefs.GetInt(GetComponent<Image>() + "equip") == 0)
            {
            }
        }
    }
    public void buy()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>() + "buy") == 0)
        {
            if (ScoreManager.Best_Score >= price)
            { 
                PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("BestScore") - price);
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
            PlayerPrefs.SetInt("SkinNum", skinNum);
        } 
    }
}
