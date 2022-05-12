using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Wandering : MonoBehaviour
{
    private Animator animator;
    private bool walking;
    // Start is called before the first frame update
    void Start()
    {  
        walking = false;
        animator = GetComponent<Animator>();
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        if(walking)
        {
            transform.Translate(Vector3.forward *3* Time.deltaTime ,Space.Self);
        }
        else
        {
        }
    }
    private void OnCollisionStay(Collision other) {
        
    }
    private void OnCollisionEnter(Collision other) {
        
        if( !(other.transform.gameObject.tag.Equals("ground")))
        {
            transform.position =Vector3.MoveTowards(transform.position,other.transform.position, -1* 30 * Time.deltaTime);

            animator.Play("sound");
            walking = false;
        }
    }


IEnumerator waiter()
{
    while(true)
    {
       Debug.Log("sleeping right now");
       walking = !walking;
       if(walking)
        animator.Play("walk");
        Vector3 rotation = new Vector3(0, Random.Range(70.0f, 90.0f), 0);
        transform.Rotate(rotation);
        yield return new WaitForSecondsRealtime(10);

    }
}
    
}
