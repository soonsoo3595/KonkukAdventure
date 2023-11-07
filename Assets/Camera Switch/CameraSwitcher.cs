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

    public LayerMask cullingMaskWhileLive;
    private LayerMask _savedLayerMask;

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
            _OnVirtualCameraAnimateIn_Finished();
            return;
        }
        else
        {
            _playerCam.Priority = 2;
            npcCam.Priority = 0;
            _isPlayerCamera = true;
            _OnVirtualCameraAnimateOut_Started();
        }
        _npcCamBuffer = npcCam;
    }

    public void _OnVirtualCameraAnimateIn_Finished()
    {
        _savedLayerMask = Camera.main.cullingMask;
        Camera.main.cullingMask = cullingMaskWhileLive;
    }

    public void _OnVirtualCameraAnimateOut_Started()
    {
        Camera.main.cullingMask = _savedLayerMask;
    }
}
