using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float fireForce;
    public float destroyTime = 2;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fireForce,ForceMode.Impulse);
        Destroy(gameObject,destroyTime);

    }

    void OnCollisionEnter(Collision other) {

        if(other.transform.root.gameObject.tag == "Player"){

            Debug.Log("HIT PLAYER");

            other.transform.root.GetComponent<PlayerController>().ResetPlayer();

        }

        Destroy(gameObject);
        
    }

}
