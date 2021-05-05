using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable;

    private Camera _sceneCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (var t in componentsToDisable)
            {
                t.enabled = false;
            }
        }
        else
        {
            _sceneCamera = Camera.main;
            if (_sceneCamera != null)
            {
                _sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if (_sceneCamera != null)
        {
            _sceneCamera.gameObject.SetActive(true);
        }
    }
}
