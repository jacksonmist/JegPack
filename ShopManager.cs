using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public UpgradeManager upgrade;

    public Text coinTotal;

    public GameObject coinButt;
    public GameObject shieldButt;
    public GameObject wingsButt;
    public GameObject boostButt;
    public GameObject glassesButt;

    public GameObject soldCoin;
    public GameObject soldShield;
    public GameObject soldWings;
    public GameObject soldBoost;
    public GameObject brokeMfer;

    public GameObject disableGlasses;
    public GameObject enableGlasses;

    public int totalCoins;
    private void Start()
    {
        if (upgrade.coinDoublerUp == 1)
        {
            coinButt.SetActive(false);
            soldCoin.SetActive(true);
        }
        if(upgrade.shieldUp == 1)
        {
            shieldButt.SetActive(false);
            soldShield.SetActive(true);
        }
        if (upgrade.wingsUp == 1)
        {
            wingsButt.SetActive(false);
            soldWings.SetActive(true);
        }
        if (upgrade.boostUp == 1)
        {
            boostButt.SetActive(false);
            soldBoost.SetActive(true);
        }
        if(upgrade.glassesUp == 1)
        {
            glassesButt.SetActive(false);
            disableGlasses.SetActive(true);
        }
        if (upgrade.glassesUp == 2)
        {
            disableGlasses.SetActive(false);
            enableGlasses.SetActive(true);
        }
        totalCoins = PlayerPrefs.GetInt("allCoins");
        coinTotal.text = totalCoins.ToString();
    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void CoinDoubler()
    {
        if(totalCoins >= 250)
        {
            PlayerPrefs.SetInt("coinDoublerUp", 1);
            coinButt.SetActive(false);
            soldCoin.SetActive(true);
            totalCoins -= 250;
            PlayerPrefs.SetInt("allCoins", totalCoins);
            coinTotal.text = totalCoins.ToString();
        }
        else
        {
            Broke();
        }
        
    }

    public void Shield()
    {
        if (totalCoins >= 100)
        {
            PlayerPrefs.SetInt("shieldUp", 1);
            shieldButt.SetActive(false);
            soldShield.SetActive(true);
            totalCoins -= 100;
            PlayerPrefs.SetInt("allCoins", totalCoins);
            coinTotal.text = totalCoins.ToString();
        }
        else
        {
            Broke();
        }
    }

    public void Wings()
    {
        if (totalCoins >= 200)
        {
            PlayerPrefs.SetInt("wingsUp", 1);
            wingsButt.SetActive(false);
            soldWings.SetActive(true);
            totalCoins -= 200;
            PlayerPrefs.SetInt("allCoins", totalCoins);
            coinTotal.text = totalCoins.ToString();
        }
        else
        {
            Broke();
        }
    }

    public void Boost()
    {
        if (totalCoins >= 300)
        {
            PlayerPrefs.SetInt("boostUp", 1);
            boostButt.SetActive(false);
            soldBoost.SetActive(true);
            totalCoins -= 300;
            PlayerPrefs.SetInt("allCoins", totalCoins);
            coinTotal.text = totalCoins.ToString();
        }
        else
        {
            Broke();
        }
    }

    public void Glassess()
    {
        if (totalCoins >= 250)
        {
            PlayerPrefs.SetInt("glassesUp", 1);
            glassesButt.SetActive(false);
            disableGlasses.SetActive(true);
            totalCoins -= 250;
            PlayerPrefs.SetInt("allCoins", totalCoins);
            coinTotal.text = totalCoins.ToString();
        }
        else
        {
            Broke();
        }

    }

    public void DisableGlasses()
    {
        PlayerPrefs.SetInt("glassesUp", 2);
        disableGlasses.SetActive(false);
        enableGlasses.SetActive(true);
    }
    public void EnableGlasses()
    {
        PlayerPrefs.SetInt("glassesUp", 1);
        disableGlasses.SetActive(true);
        enableGlasses.SetActive(false);
    }

    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Broke()
    {
        StartCoroutine(BrokeSprite());
    }

    IEnumerator BrokeSprite()
    {
        brokeMfer.SetActive(true);
        yield return new WaitForSeconds(2);
        brokeMfer.SetActive(false);
    }
}
