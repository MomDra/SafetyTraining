using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePassCheck : MonoBehaviour
{
    public bool benzenPassCheck;
    public bool correctPosPassCheck;
    public bool flammabilityPassCheck;
    public bool wasteFluidPassCheck;
    public bool wrongWasteFluidPassCheck;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BottlePassCheck Start");
    }

    // Update is called once per frame
    void Update()
    {
        benzenPassCheck = true;
        correctPosPassCheck = true;
        flammabilityPassCheck = true;
        wasteFluidPassCheck = true;
        wrongWasteFluidPassCheck = true;

        foreach (Transform child in transform)
        {
            if (!child.GetComponent<FridgeRecogSol>().benzenPass)
            {
                //벤젠 통과 못함
                benzenPassCheck = false;
            }
            if (!child.GetComponent<FridgeRecogSol>().correctPosPass)
            {
                //시약 구분 못함
                correctPosPassCheck = false;
            }
            if (!child.GetComponent<FridgeRecogSol>().flammabilityPass)
            {
                //인화성 통과 못함
                flammabilityPassCheck = false;
            }

            foreach(Transform childChild in child)
            {
                if(childChild.name == "용액 파티클")
                {
                    //잘못된 폐액 처리
                    if (!childChild.GetComponent<ParticleCollision>().wasteFluidPass)
                    {
                        wasteFluidPassCheck = false;
                    }
                    if (!childChild.GetComponent<ParticleCollision>().ExpirationDate && !childChild.GetComponent<ParticleCollision>().wrongWasteFluidPass)
                    {
                        wrongWasteFluidPassCheck = false;
                    }

                }
            }

        }
        if (benzenPassCheck) transform.GetComponent<BenzenPass>().Solve();
        else transform.GetComponent<BenzenPass>().NotSolve();

        if (correctPosPassCheck) transform.GetComponent<CorrectPosPass>().Solve();
        else transform.GetComponent<CorrectPosPass>().NotSolve();

        if (flammabilityPassCheck) transform.GetComponent<FlammabilityPass>().Solve();
        else transform.GetComponent<FlammabilityPass>().NotSolve();

        if (wasteFluidPassCheck) transform.GetComponent<WasteFluidPass>().Solve();
        else transform.GetComponent<WasteFluidPass>().NotSolve();

        if (wrongWasteFluidPassCheck) transform.GetComponent<WrongWasteFluidPass>().Solve();
        else transform.GetComponent<WrongWasteFluidPass>().NotSolve();
        /*
        Debug.Log("benzenPassCheck : " + benzenPassCheck);
        Debug.Log("correctPosPassCheck : " + correctPosPassCheck);
        Debug.Log("flammabilityPassCheck : " + flammabilityPassCheck);
        Debug.Log("wasteFluidPassCheck : " + wasteFluidPassCheck);
        Debug.Log("wrongWasteFluidPassCheck : " + wrongWasteFluidPassCheck);
        */
    }
}
