using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CustomEvent rootComming,IntroDone;
    private CinemachineVirtualCamera virtualCamera;
    private GameObject cinemachineCameraTarget;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineCameraTarget = GameObject.FindGameObjectWithTag("PlayerCameraRoot");
    }

    public void OnIntroDone()
    {
        if(virtualCamera != null)
        virtualCamera.Follow = cinemachineCameraTarget.transform;
        IntroDone.Occurred();
    }
    public void OnRootCome()
    {
        rootComming.Occurred();
    }
}
