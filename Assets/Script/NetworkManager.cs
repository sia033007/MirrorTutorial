using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManager : NetworkBehaviour
{
    [Client]
    private void Update() {
        if(isLocalPlayer){
            float horizpntalmove = Input.GetAxis ("Horizontal");
            float verticalmove = Input.GetAxis ("Vertical");
            Vector3 movement= new Vector3 (horizpntalmove *0.1f,verticalmove*0.1f,0);
            transform.position = transform.position + movement;
        }       
    }
}
