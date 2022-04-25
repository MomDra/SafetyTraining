using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTask : Task
{

    void Start(){
        Invoke("Solve", 5f);
        Debug.Log("Start() 호출!");
    }

    void Update(){
        //Debug.Log("왜 그래 됑ㄹㅁ나렁미;ㄴ");
    }
}
