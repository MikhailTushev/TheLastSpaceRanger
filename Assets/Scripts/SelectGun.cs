using UnityEngine;

public class SelectGun : MonoBehaviour
{
    public GameObject Gun1, Gun2, Gun3;
    int selectGun1, selectGun2, selectGun3;
    static int selected;

    // Start is called before the first frame update
    void Start()
    {
        if (selected == 0)
        {
            selectGun1 = PlayerPrefs.GetInt("selectGun1", 1);
            selectGun2 = PlayerPrefs.GetInt("selectGun2", 1);
            selectGun3 = PlayerPrefs.GetInt("selectGun3", 1);
        }
        else
        {
            selectGun1 = PlayerPrefs.GetInt("selectGun1", selected);
            selectGun2 = PlayerPrefs.GetInt("selectGun2", selected);
            selectGun3 = PlayerPrefs.GetInt("selectGun3", selected);
        }
    }

    void Update()
    {
        if (selectGun1 == 1)
        {
            selected = 1;
            PlayerPrefs.GetInt("selected", 1);
            Gun1.SetActive(true);
            Gun2.SetActive(false);
            Gun3.SetActive(false);
        }
        else
        {
            Gun1.SetActive(false);
        }
        if (selectGun1 == 2)
        {
            selected = 2;
            PlayerPrefs.GetInt("selected", 2);
            Gun2.SetActive(true);
            Gun1.SetActive(false);
            Gun3.SetActive(false);
        }
        else
        {
            Gun2.SetActive(false);
        }
        if (selectGun1 == 3)
        {
            selected = 3;
            PlayerPrefs.GetInt("selected", 3);
            Gun3.SetActive(true);
            Gun2.SetActive(false);
            Gun1.SetActive(false);
        }
        else
        {
            Gun3.SetActive(false);
        }
    }

    public void SelectOneGun()
    {
        if (MoneyText.coins >= 100)
        {
            MoneyText.coins -= 100;
            selectGun1 = 1;
            PlayerPrefs.GetInt("selectGun1", selectGun1);
            selectGun2 = 1;
            PlayerPrefs.GetInt("selectGun2", selectGun2);
            selectGun3 = 1;
            PlayerPrefs.GetInt("selected", selectGun1);
            selected = 1;
            PlayerPrefs.GetInt("selectGun3", selectGun3);
            PlayerPrefs.SetInt("coins", MoneyText.coins);
        }
    }

    public void SelectTwoGun()
    {
        if (MoneyText.coins >= 50)
        {
            MoneyText.coins -= 50;
            selectGun1 = 2;
            selected = 2;
            PlayerPrefs.GetInt("selected", selectGun1);
            PlayerPrefs.GetInt("selectGun1", selectGun1);
            selectGun2 = 2;
            PlayerPrefs.GetInt("selectGun2", selectGun2);
            selectGun3 = 2;
            PlayerPrefs.GetInt("selectGun3", selectGun3);
            PlayerPrefs.SetInt("coins", MoneyText.coins);
        }
    }

    public void SelectThreeGun()
    {
        if (MoneyText.coins >= 150)
        {
            selected = 3;
            MoneyText.coins -= 150;
            selectGun1 = 3;
            PlayerPrefs.GetInt("selected", selectGun1);
            PlayerPrefs.GetInt("selectGun1", selectGun1);
            selectGun2 = 3;
            PlayerPrefs.GetInt("selectGun2", selectGun2);
            selectGun3 = 3;
            PlayerPrefs.GetInt("selectGun3", selectGun3);
            PlayerPrefs.SetInt("coins", MoneyText.coins);
        }
    }
}
