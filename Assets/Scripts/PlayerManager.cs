using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    GameObject controller;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    private void CreateController()
    {
        Transform spawnPoint = SpawnManager.instance.GetSpawnPoint();
       controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerController"),spawnPoint.position,spawnPoint.rotation, 0, new object[] {PV.ViewID});   
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
