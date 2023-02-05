using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.waterCollected==5)
        {
            anim.SetTrigger("OpenGate");
            StartCoroutine("Time5s");
        }
    }
    IEnumerator Time5s()
    {
        yield return new WaitForSeconds(2);
        GameManager.NextLevel();
    }
}
