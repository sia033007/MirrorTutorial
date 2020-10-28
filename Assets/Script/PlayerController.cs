using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    Rigidbody rb;
    public GameObject spawnPos;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
             CmdMove();
             if(Input.GetKeyDown(KeyCode.Space)){
                 CmdSpawn();
             }
        }
       
    }
    [Command]
    void CmdMove(){
        RpcMove();
    }
    [ClientRpc]
    void RpcMove(){
        if(!isServer){
            MovePlayer();
        }
       
    }
    [Command]
    void CmdSpawn(){
        RpcSpawn();
    }
    [ClientRpc]
    void RpcSpawn(){
        GameObject bullet = Instantiate (bulletPrefab,spawnPos.transform.position,Quaternion.identity);
        bullet.transform.SetParent(spawnPos.transform);
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward *1000f);
        Destroy(bullet.gameObject,2f);

    }
    void MovePlayer(){
        float horizontalmove = Input.GetAxis("Horizontal");
        float verticalmove = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalmove *5f,verticalmove *5f,0);

    }
}
