using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Animator anim;
    private int collectedWater=0;
    CustomEvent waterCollected;
    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.CompareTag("Water"))
        {
            collectedWater++;
            other.gameObject.GetComponent<Animator>().SetBool("pickUp", true);
           // waterCollected.Occurred();
            //other.gameObject.SetActive(false);
        }
        if (other.CompareTag("End") && collectedWater==5)
        {
            anim.SetBool("EndLevel", true);
        }
    }

    public void RootCome()
    {
        anim.SetTrigger("IntroEnter");
    }
}
