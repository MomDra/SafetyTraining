using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BottleManager
{
    public bool benzenPassCheck;
    public bool correctPosPassCheck;
    public bool flammabilityPassCheck;
    public bool wasteFluidPassCheck;
    public bool wrongWasteFluidPassCheck;

    List<FridgeRecogSol> fridgeRecogSolList = new List<FridgeRecogSol>();
    List<ParticleCollision> particleCollisionList = new List<ParticleCollision>();

    public void registFridgeRecogSolList(FridgeRecogSol fridgeRecogSol){
        fridgeRecogSolList.Add(fridgeRecogSol);
    }
    public void registParticleCollision(ParticleCollision particleCollision)
    {
        particleCollisionList.Add(particleCollision);
    }

    public void Check(){
        
    }

    public void BenzenPassCheck(){
        foreach(FridgeRecogSol item in fridgeRecogSolList){
            if (!item.correctPosPass && !item.benzenPass){
                //벤젠 통과 못함
                benzenPassCheck = false;
                break;
            }
        }
    }

    public void CorrectPosPassCheck(){
        foreach(FridgeRecogSol item in fridgeRecogSolList){
            if (!item.correctPosPass){
                //시약 구분 못함
                correctPosPassCheck = false;
                break;
            }
        }
    }

    public void FlammabilityPassCheck(){
        foreach(FridgeRecogSol item in fridgeRecogSolList){
            if (!item.correctPosPass && !item.flammabilityPass)
            {
                //인화성 통과 못함
                flammabilityPassCheck = false;
                break;
            }
        }   
    }

    public void WasteFluidPassCheck()
    {
        foreach (ParticleCollision item in particleCollisionList)
        {
            if (!item.ExpirationDate && !item.wasteFluidPass)
            {
                //폐액처리 통과 못함
                wasteFluidPassCheck = false;
                break;
            }
        }
    }
    public void WrongWasteFluidPassCheck()
    {
        foreach (ParticleCollision item in particleCollisionList)
        {
            if (!item.wrongWasteFluidPass)
            {
                //폐액처리 통과 못함
                wrongWasteFluidPassCheck = false;
                break;
            }
        }
    }

    // 마지막 UI에는 딱 한번만 체크해서 띄어주면되는데
    // 힌트 실시간...
}