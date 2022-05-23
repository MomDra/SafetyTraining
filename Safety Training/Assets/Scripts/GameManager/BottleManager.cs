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

    public void registFridgeRecogSolList(FridgeRecogSol fridgeRecogSol){
        fridgeRecogSolList.Add(fridgeRecogSol);
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

    // 마지막 UI에는 딱 한번만 체크해서 띄어주면되는데
    // 힌트 실시간...
}