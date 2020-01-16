using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast_robot : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator> ();
        
    }

    // Update is called once per frame
    void Update()
    { RaycastHit hit;
    //부딛치는 물체의 정보를 담는 변수 hit 선언
    Vector3 forward = transform.TransformDirection(Vector3.forward)*1000;
    //forward라는 이름의 방향변수 선언 및 대입
    Debug.DrawRay(transform.position, forward, Color.green);
    //가상의 레이인 레이캐스트를 테스트 중에는 보일 수 있도록 함
    if (Physics.Raycast (transform.position, forward, out hit)){
        Debug.Log("hit");
        anim.SetBool("isHit",true);
        //만약에 레이캐스트가 어떠한 물체에 맞는다면 hit라는 문구를 냄
    }
        
    }
}
