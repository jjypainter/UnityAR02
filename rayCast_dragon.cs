using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast_dragon : MonoBehaviour
{
    Animator anim;

    public int atkPnt;
    public int hltPnt;

    float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        anim=transform.GetComponent<Animator> ();

        atkPnt=200;
        hltPnt=5000;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //부딛히는 물체의 정보를 담는 변수 hit선언
        Vector3 forward = transform.TransformDirection(Vector3.forward)*1000;
        //forward라는 이름의 방향변수 선언및 대입
        Debug.DrawRay(transform.position, forward, Color.green);
        //가상의 레이인 레이캐스트를 테스트 중에는 보일 수 있도록 함
        if (Physics.Raycast(transform.position, forward, out hit)){
            Debug.Log("hit");
            anim.SetBool("isHit", true);
            timeElapsed=timeElapsed+Time.deltaTime;
            if (timeElapsed>=3){
                hit.transform.GetComponent<rayCast_robot>().hltPnt=
                    hit.transform.GetComponent<rayCast_robot>().hltPnt-atkPnt;
                timeElapsed=0;
            }
        }else{
            anim.SetBool("isHit", false);
        }
        
    }
}
