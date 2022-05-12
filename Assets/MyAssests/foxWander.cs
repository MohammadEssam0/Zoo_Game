using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class foxWander : MonoBehaviour
{
    private Animator animator;
    private bool walking;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {  
        speed = 2;
        walking = false;
        animator = GetComponent<Animator>();
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        if(walking)
        {
            transform.Translate(Vector3.forward *speed* Time.deltaTime ,Space.Self);
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
            transform.position = Vector3.MoveTowards(transform.position,other.transform.position, -1* 30 * Time.deltaTime);
            animator.Play("idle");
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
        animator.Play("jump");
        Vector3 rotation = new Vector3(0, Random.Range(0.0f, 90.0f), 0);
        transform.Rotate(rotation);
        yield return new WaitForSecondsRealtime(10);

    }
}
    
}
