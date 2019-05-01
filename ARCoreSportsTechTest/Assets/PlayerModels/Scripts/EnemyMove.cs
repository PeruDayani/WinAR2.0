using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public  GameObject enemyOnGround;
    public static int i = 0;
   
    CharacterController charCont;
    public GameObject ARCamera;
    public static Vector3 dir;
    public static bool ReadyToMove = false;
    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void Ready()
    {


        dir = ARCamera.transform.position - enemyOnGround.transform.position;
        ReadyToMove = true;
        anim.SetTrigger("Run");
        



    }
}
