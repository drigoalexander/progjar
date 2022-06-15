<<<<<<< HEAD
﻿using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NetworkedPlayer : MonoBehaviourPunCallbacks {

    public static GameObject localPlayerInstance;
    public GameObject playerNamePrefab;
    public Rigidbody rb;
    public Renderer jeepMesh;

    private void Awake() {

        if (photonView.IsMine) {

            localPlayerInstance = gameObject;
        } else {

            GameObject playerName = Instantiate(playerNamePrefab);
            playerName.GetComponent<NameUIController>().target = rb.gameObject.transform;
            string sentName = null;
            if (photonView.InstantiationData != null)
                sentName = (string)photonView.InstantiationData[0];

            if (sentName != null)
                playerName.GetComponent<Text>().text = sentName;
            else
                playerName.GetComponent<Text>().text = photonView.Owner.NickName;

            playerName.GetComponent<NameUIController>().carRend = jeepMesh;
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Realtime;
using Photon.Pun;

public class NetworkedPlayer : MonoBehaviourPunCallbacks
{
    public static GameObject LocalPlayerInstance;
    public GameObject playerNamePrefab;
    public Rigidbody rigidBody;
    public Renderer vehicleMesh;

}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
