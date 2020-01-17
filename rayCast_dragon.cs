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

        atkPnt=200; //공격력
        hltPnt=5000; //체력
        
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
            timeElapsed=timeElapsed+Time.deltaTime; //초 단위로 지나가는 시간
            if (timeElapsed>=3){ //3초에 한번씩 공격
                hit.transform.GetComponent<rayCast_robot>().hltPnt=
                    hit.transform.GetComponent<rayCast_robot>().hltPnt-atkPnt;
                //상대방의 체력에서 공격력을 뺀다
                timeElapsed=0; //시간 초기화
            }
        }else{
            anim.SetBool("isHit", false);
        }
        if(hltPnt<=0){
            anim.SetBool("isDead", true);
        }
        
    }
}
