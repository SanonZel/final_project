using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignSkin : MonoBehaviour
{
    public SpriteRenderer Player;
    public Sprite Standart;

    private const string _PURCHASE_CURRENT_SKIN_NAME = "currentSkin";
    [SerializeField] private List<Sprite> _skins = new List<Sprite>();

    void Start()
    {
        int skinNum = PlayerPrefs.GetInt(_PURCHASE_CURRENT_SKIN_NAME);
        if (skinNum < _skins.Count)
            Player.sprite = _skins[skinNum];
        else
            Player.sprite = Standart;
        Debug.Log(skinNum + " Skin NUm => " + Time.time);
    }

    void Update()
    {

    }
}
