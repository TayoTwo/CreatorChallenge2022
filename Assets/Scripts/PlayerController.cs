using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float accel;
    public float deccel;
    public float maxSpeed;
    public int score;
    Vector3 hitPoint;
    UIManager uIManager;
    PlayerController otherPlayer;
    PlayerSpawner playerSpawner;
    ScoreManager scoreManager;
    PhotonView view;
    Rigidbody rb;
    Vector3 mousePos;
    InputMaster inputMaster;

    void OnEnable(){

        inputMaster.Enable();

    }

    void OnDisable(){

        inputMaster.Disable();

    }

    // Start is called before the first frame update
    void Awake()
    {

        playerSpawner = FindObjectOfType<PlayerSpawner>();
        scoreManager = FindObjectOfType<ScoreManager>();
        uIManager = FindObjectOfType<UIManager>();

        scoreManager.OnPlayerJoin(this);
        uIManager.localPlayer = this;

        otherPlayer = scoreManager.players.Find(x => x.gameObject != gameObject);

        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();

        if(view.IsMine){

            inputMaster = new InputMaster();
            inputMaster.Player.Fire.performed += ctx => Fire();        

        }

    }

    void FixedUpdate() {

        if(view.IsMine){

            Move(inputMaster.Player.Movement.ReadValue<Vector2>());
        
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(view.IsMine){

            Aim();

        }

    }

    void Move(Vector2 inputDir){

        //Debug.Log(inputDir);
        Vector3 moveDir = new Vector3(inputDir.x,0,inputDir.y);

        //Debug.Log(moveDir);

        rb.AddForce(moveDir * accel,ForceMode.Acceleration);

        if(rb.velocity.magnitude > maxSpeed){

            rb.velocity = rb.velocity.normalized * maxSpeed;

        }

        if(inputDir == Vector2.zero){

            rb.AddForce(-rb.velocity.normalized * deccel,ForceMode.Acceleration);

        }

    }

    void Aim(){

        mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){

            hitPoint = hit.point;

        }

        hitPoint.y = transform.position.y;

        //Debug.Log(hitPoint);

        transform.LookAt(hitPoint);

    }


    public void Fire(){

        PhotonNetwork.Instantiate(projectilePrefab.name,spawnPoint.position,transform.rotation);

    }

    private void OnDrawGizmos() {
        
        Gizmos.DrawWireSphere(hitPoint,0.5f);

    }

    public void ResetPlayer(){

        scoreManager.players.Find(x => x.gameObject != gameObject).score++;
        transform.position = new Vector3(Random.Range(-playerSpawner.spawnRange.x,playerSpawner.spawnRange.x),0,Random.Range(-playerSpawner.spawnRange.y,playerSpawner.spawnRange.y));

    }

}
