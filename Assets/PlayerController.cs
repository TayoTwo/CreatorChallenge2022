using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float accel;
    public float maxSpeed;
    InputMaster inputMaster;

    // Start is called before the first frame update
    void Start()
    {
        
        inputMaster = new InputMaster();

        inputMaster.Player.Fire.performed += ctx => Fire();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(){



    }

    void Aim(){



    }

    public void Fire(){



    }
}
