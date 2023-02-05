using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CustomEvent rootComming;
    private CinemachineVirtualCamera virtualCamera;
    private GameObject cinemachineCameraTarget;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineCameraTarget = GameObject.FindGameObjectWithTag("PlayerCameraRoot");
    }

    public void OnIntroDone()
    {
        virtualCamera.Follow = cinemachineCameraTarget.transform;
    }
    public void OnRootCome()
    {
        rootComming.Occurred();
    }
}
