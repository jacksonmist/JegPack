using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    ZapperSpawn spawn;
    Animator anim;
    [SerializeField] float speed;
    bool collided;
    void Start()
    {
        anim = GetComponent<Animator>();
        spawn = GameObject.Find("ZapperSpawn").GetComponent<ZapperSpawn>();
    }

    
    void Update()
    {
        Movement();
        EdgeCheck();        
    }

    void Movement()
    {
        transform.position = new Vector3(transform.position.x - speed * spawn.disMult * Time.deltaTime, transform.position.y, -1);
    }

    void EdgeCheck()
    {
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collided = true;
        }
    }

    void CoinCollected()
    {
        if(collided == true)
        {
            anim.SetTrigger("Collected");
        }
    }

    void DestroyCoin()
    {
        Destroy(gameObject);
    }

    
}
