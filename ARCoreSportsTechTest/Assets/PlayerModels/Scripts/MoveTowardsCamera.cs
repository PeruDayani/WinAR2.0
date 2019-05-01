using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCamera : MonoBehaviour
{
   // public bool charEnabled = false;
    public Animator anim;
    public GameObject ARCamera;
    public CharacterController charCont;
    bool IsResize = false;

    
    void Start()
    {
        charCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyMove.ReadyToMove)
        {
            charCont.Move(EnemyMove.dir *0.5f* Time.deltaTime);
            //anim.Play("Run");
        }
        this.transform.LookAt(new Vector3( ARCamera.transform.position.x, 0, ARCamera.transform.position.z));


        if (IsResize)
        {
            Vector3 temp = this.transform.localScale;
            Vector3 tempPos = this.transform.position;
            tempPos.y += 0.5f * Time.deltaTime;
            temp.x += 0.5f * Time.deltaTime;
            temp.y += 0.5f * Time.deltaTime;
            temp.z += 0.5f * Time.deltaTime;
            this.transform.localScale = temp;
            this.transform.position = tempPos;
        }
       

            
    }
    public void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("CamPosition"))
        charCont.enabled = false;
        anim.SetTrigger("Tackle");

        StartCoroutine(DestroyEnemy());
       


    }
    public  void DirectionOfPlayer()
    {
      /*  this.GetComponent<CharacterController>().enabled = true;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Run");
        GameObject ARCamera = GameObject.FindGameObjectWithTag("MainCamera");
        EnemyMove.dir = ARCamera.transform.position - transform.position;
        */
    }
    public void Resize(bool b)
    {
        IsResize = b;
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
