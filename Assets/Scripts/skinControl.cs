using UnityEngine;
using UnityEngine.UI;

public class skinControl : MonoBehaviour
{

    public int skinNum;
    public Button buyButton;
    public Image iLock;
    public int price;
    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;
    public Sprite falseLock;
    public Sprite trueLock;
    public Text moneyText;
    public Image[] skins;
    public int money;

    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("skin1" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                if ("skin1" == img.name)
                {
                    PlayerPrefs.SetInt("skin1" + "buy", 1);
                    PlayerPrefs.SetInt("skin1" + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);
                }
            }
        }
    }

    private void Update()
    {
        money = PlayerPrefs.GetInt("money");
        moneyText.text = money.ToString();
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            iLock.GetComponent<Image>().sprite = falseLock;
            buyButton.GetComponent<Image>().sprite = buySkin;
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            iLock.GetComponent<Image>().sprite = trueLock;
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 1)
            {
                buyButton.GetComponent<Image>().sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
            {
                buyButton.GetComponent<Image>().sprite = equip;
            }
        }
    }
    public void buy()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (money >= price)
            {
                iLock.GetComponent<Image>().sprite = trueLock;
                buyButton.GetComponent<Image>().sprite = equipped;
                PlayerPrefs.SetInt("money",money-price);
                print(money);
                moneyText.text = "Money:" + money.ToString();
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach (Image img in skins)
                {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "equip", 0);
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            iLock.GetComponent<Image>().sprite = trueLock;
            buyButton.GetComponent<Image>().sprite = equipped;
            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (Image img in skins)
            {
                if (GetComponent<Image>().name == img.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "equip", 0);
                }
            }
        }
    }
}