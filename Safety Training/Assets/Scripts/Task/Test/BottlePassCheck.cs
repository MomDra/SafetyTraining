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
                //���� ��� ����
                benzenPassCheck = false;
            }
            if (!child.GetComponent<FridgeRecogSol>().correctPosPass)
            {
                //�þ� ���� ����
                correctPosPassCheck = false;
            }
            if (!child.GetComponent<FridgeRecogSol>().flammabilityPass)
            {
                //��ȭ�� ��� ����
                flammabilityPassCheck = false;
            }

            foreach(Transform childChild in child)
            {
                if(childChild.name == "��� ��ƼŬ")
                {
                    //�߸��� ��� ó��
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
