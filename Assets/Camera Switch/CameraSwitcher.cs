using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{

    public static CameraSwitcher cameraSwitcher;

    [SerializeField] private CinemachineVirtualCamera _playerCam;
    [SerializeField] private CinemachineVirtualCamera _npcCamBuffer;

    private bool _isPlayerCamera = true;

    void Awake()
    {
        cameraSwitcher = this;
    }

    public void SwitchPrioroty(CinemachineVirtualCamera npcCam)
    {
        if (_isPlayerCamera)
        {
            _playerCam.Priority = 0;
            npcCam.Priority = 1;
            _isPlayerCamera = false;
            return;
        }
        else
        {
            _playerCam.Priority = 2;
            npcCam.Priority = 0;
            _isPlayerCamera = true;
        }
        _npcCamBuffer = npcCam;
    }
}
