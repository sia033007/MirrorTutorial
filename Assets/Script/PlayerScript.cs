using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    [SyncVar (hook = nameof (OnChangeHola))]
    public int holacount =0;
    private void Update() {
        if(isLocalPlayer){
            float horizpntalmove = Input.GetAxis ("Horizontal");
            float verticalmove = Input.GetAxis ("Vertical");
            Vector3 movement= new Vector3 (horizpntalmove *0.1f,verticalmove*0.1f,0);
            transform.position = transform.position + movement;
            if(Input.GetKeyDown(KeyCode.A)){
                Debug.Log("Sending hola to the Server!");
                hola();

            }
        }     
    }
    [Command]
    void hola(){
        Debug.Log("Received hola from Client!");
        ReplyHola();
        holacount++;
    }
    [ClientRpc]
    void TooHigh(){
        Debug.Log("Too High!");
    }
    [TargetRpc]
    void ReplyHola(){
        Debug.Log("Received hola from the Server!");
    }
    void OnChangeHola(int oldhola, int newhola){
        Debug.Log("oldhola : " + oldhola);
        Debug.Log("newhola : " + newhola);
    }
}
