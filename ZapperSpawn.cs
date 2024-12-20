using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapperSpawn : MonoBehaviour
{
    public GameObject zapper;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;

    float zapTimer = 0;
    float coinTimer = 0;
    public float disMult;
    public float disTrav;

    [SerializeField] float zapRate = 8;
    [SerializeField] float coinRate = 9;

    void Start()
    {

    }


    void Update()
    {
        ZapperInstan();
        CoinInstan();
        DistanceMultiplier();



    }

    void DistanceMultiplier()
    {
        disMult += .05f * Time.deltaTime;
        if (disMult >= 2)
        {
            disMult = 2;
        }

        disTrav += Time.deltaTime * disMult * 10;

    }

    void CoinInstan()
    {
        coinTimer += Time.deltaTime;
        if (coinTimer > coinRate - disMult)
        {
            float randHeight = Random.Range(-2f, 2f);
            int randPref = Random.Range(1, 3);
            switch (randPref)
            {
                case 1:
                    GameObject newCoin1 = Instantiate(coin1, new Vector2(12, randHeight), transform.rotation);
                    break;
                case 2:
                    GameObject newCoin2 = Instantiate(coin2, new Vector2(12, randHeight), transform.rotation);
                    break;
                case 3:
                    GameObject newCoin3 = Instantiate(coin3, new Vector2(12, randHeight), transform.rotation);
                    break;
            }

            coinTimer = 0;
        }
    }


    void ZapperInstan()
    {
        zapTimer += Time.deltaTime;
        if (zapTimer > zapRate - disMult)
        {
            DoubleZapper();

            zapTimer = 0;
        }
    }

    void DoubleZapper()
    {
        int randSpawn = Random.Range(0, 3);
        if (randSpawn == 1)
        {
            GameObject newZap = Instantiate(zapper, new Vector2(12, RandomHeight()), Quaternion.Euler(new Vector3(0, 0, RandomRotation())));
            GameObject newZap2 = Instantiate(zapper, new Vector2(18, RandomHeight()), Quaternion.Euler(new Vector3(0, 0, RandomRotation())));
        }
        else if(randSpawn == 2)
        {
            GameObject newZap = Instantiate(zapper, new Vector2(12, RandomHeight()), Quaternion.Euler(new Vector3(0, 0, RandomRotation())));
            GameObject newZap2 = Instantiate(zapper, new Vector2(20, RandomHeight()), Quaternion.Euler(new Vector3(0, 0, RandomRotation())));
            GameObject newZap3 = Instantiate(zapper, new Vector2(28, RandomHeight()), Quaternion.Euler(new Vector3(0, 0, RandomRotation())));
        }
        else
        {

            GameObject newZap = Instantiate(zapper, new Vector2(12, RandomHeight()), Quaternion.Euler(new Vector3(0, 0, RandomRotation())));
        }
        Debug.Log(randSpawn);
    }

    int RandomRotation()
    {
        int randRot = Random.Range(0, 3);
        switch (randRot)
        {
            case 0:
                randRot = 0;
                break;
            case 1:
                randRot = 45;
                break;
            case 2:
                randRot = 90;
                break;
            case 3:
                randRot = 180;
                break;
        }
        return randRot;
    }

    float RandomHeight()
    {
        float randHeight = Random.Range(-4f, 4f);
        return randHeight;
    }

}
