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
        if (other.CompareTag("Water"))
        {
            collectedWater++;
            other.gameObject.GetComponent<Animator>().SetBool("pickUp", true);
           // waterCollected.Occurred();
            //other.gameObject.SetActive(false);
        }
        if (other.CompareTag("End") && collectedWater==5)
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("OpenGate");
            anim.SetBool("EndLevel", true);
        }
        if (other.CompareTag("Seed"))
        {
            coll = other;
            anim.SetBool("CanPickUp",true);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Seed"))
        {
            anim.SetBool("CanPickUp", false);
        }
    }
    Collider coll;
    [SerializeField]
    private Transform leftHandTransform;
    public void OnGrabAnimation()
    {
        coll.gameObject.transform.position = leftHandTransform.position;
        coll.gameObject.transform.position = coll.ClosestPoint(coll.gameObject.transform.position) - Vector3.up * 0.1f;
        coll.gameObject.transform.SetParent(leftHandTransform, true);

    }
    public void AnimationDone()
    {
        anim.SetBool("PickUp", false);
        anim.SetBool("CanPickUp", false);
        //coll.gameObject.transform.parent.DetachChildren();
        //coll.gameObject.SetActive(false);
    }
    public void RootCome()
    {
        anim.SetTrigger("IntroEnter");
    }
}
