using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleAppear : MonoBehaviour
{
    [SerializeField]
    CustomEvent rootCome;
    Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartDiggingGround()
    {
        Debug.Log("KOPIEMY");
        anim.SetTrigger("IntroCome");
    }
    public void RootCome()
    {
        rootCome.Occurred();
    }
}
