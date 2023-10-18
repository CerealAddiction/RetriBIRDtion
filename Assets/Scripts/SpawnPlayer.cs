using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    private GameObject _curPlayer;

    //public bool _once = false;
    //public GameObject endScreen;

    void Update()
    {
        if (_curPlayer == null)
        {
            SpawnNewPlayer();
        }

    }

    private void SpawnNewPlayer()
    {
        GameObject go = Instantiate(_playerObject, transform.position, transform.rotation) as GameObject;
        _curPlayer = go;
    }
}
