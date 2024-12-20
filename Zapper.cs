using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : MonoBehaviour
{
    ZapperSpawn spawn;
    
    [SerializeField] float speed;
    bool isTrigger;
    Rigidbody2D myrb;
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
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
        if(transform.position.x < -12)
        {
            Destroy(gameObject);                     
        }
    }
}
