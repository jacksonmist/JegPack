using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerController player;
    public int coinDoublerUp;
    public int shieldUp;
    public int wingsUp;
    public int boostUp;
    public int glassesUp;
    void Awake()
    {
        coinDoublerUp = PlayerPrefs.GetInt("coinDoublerUp");
        shieldUp = PlayerPrefs.GetInt("shieldUp");
        wingsUp = PlayerPrefs.GetInt("wingsUp");
        boostUp = PlayerPrefs.GetInt("boostUp");
        glassesUp = PlayerPrefs.GetInt("glassesUp");
    }

    
    void Update()
    {
        
    }
}
