using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public static int coins;
    public Text moneyDisplay;

    private void Start()
    {
        moneyDisplay = GetComponent<Text>();
        coins = PlayerPrefs.GetInt("coins", coins);
    }

    private void Update()
    {
        moneyDisplay.text = coins.ToString();
    }
}
