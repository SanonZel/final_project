using UnityEngine;

public class ShopManager : MonoBehaviour
{

    private const string _PURCHASE_CURRENT_SKIN_NAME = "currentSkin";

    public void BuySkin(int skinId)
    {
        PlayerPrefs.SetInt(_PURCHASE_CURRENT_SKIN_NAME, skinId);
    }

}
