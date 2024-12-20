using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ZapperSpawn spawn;
    public UpgradeManager upgrade;
    public UiManager ui;

    public GameObject shield;
    public GameObject wings;
    public SpriteRenderer sprite;
    public GameObject boost;
    public GameObject glasses;
    public Rigidbody2D myrb;

    [SerializeField] float speed;
    [SerializeField] float gravity;
    [SerializeField] float health;
    Animator anim;

    public int coins;
    public int boostCoins;
    public float score;
    void Start()
    {
        anim = GetComponent<Animator>();
        myrb = GetComponent<Rigidbody2D>();
        if (upgrade.shieldUp == 1)
        {
            health = 2;
            shield.SetActive(true);
        }
        else
        {
            health = 1;
            shield.SetActive(false);
        }
        if(upgrade.glassesUp == 1)
        {
            glasses.SetActive(true);
        }
    }

    
    void LateUpdate()
    {
        Movement();
        
    }

    void Movement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * gravity);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            anim.SetTrigger("InAir");
            gravity = 7;
        }
    }

    public void Health()
    {
        
        health -= 1;
        if(health <= 0)
        {
            if(upgrade.wingsUp == 1)
            {
                StartCoroutine(WingRespawn());
            }
            else
            {
                Destroy(gameObject);
                ui.GameOver();
            }            
        }
        if (health == 1)
        {
            shield.SetActive(false);
        }

    }

    public void Coins()
    {
        if (upgrade.coinDoublerUp == 1)
        {
            coins += 2;
        }
        else
        {
            coins++;
        }
        if (upgrade.boostUp == 1)
        {
            if(coins % 50 == 0)
            {
                spawn.disTrav += 200;
                StartCoroutine(BoostActivate());
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Zapper(Clone)")
        {
            Health();
        }
        if(collision.gameObject.name == "Coin")
        {
            Coins();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            gravity = 0;
            anim.SetTrigger("OnGround");
        }
        
        
    }

    IEnumerator WingRespawn()
    {
        health = 5;
        sprite.enabled = false;
        Debug.Log("Step1");
        yield return new WaitForSeconds(2);
        Debug.Log("Step2");
        sprite.enabled = true;
        upgrade.wingsUp = 0;
        wings.SetActive(true);
        health = 1;
    }

    IEnumerator BoostActivate()
    {
        boost.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        boost.SetActive(false);
    }
}

