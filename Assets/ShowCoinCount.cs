using UnityEngine;

using TMPro;

public class ShowCoinCount : MonoBehaviour
{
    public TMP_Text coinText;
    void Start()
    {
        int coins = PlayerPrefs.GetInt("CointCount",0);
        coinText.text = "Coins: " + coins.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
}
