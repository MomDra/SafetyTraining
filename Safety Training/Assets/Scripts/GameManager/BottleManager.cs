using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BottleManager
{
    private bool benzenPassCheck;
    private bool correctPosPassCheck;
    public bool _CorrectPosPassCheck {get => correctPosPassCheck;}
    private bool flammabilityPassCheck;
    private bool wasteFluidPassCheck;
    public bool _WasteFluidPassCheck {get => wasteFluidPassCheck;}
    private bool wrongWasteFluidPassCheck;
    private bool spillPassCheck;
    private bool destructionPassCheck;

    public Task benzenPass;
    public Task correctPosPass;
    public Task flammabilityPass;
    public Task wasteFluidPass;
    public Task wrongWasteFluidPass;

    List<FridgeRecogSol> fridgeRecogSolList = new List<FridgeRecogSol>();
    List<ParticleCollision> particleCollisionList = new List<ParticleCollision>();
    List<Destructible> destructibleList = new List<Destructible>();

    UI_Manager_Hint hint;

    public void registFridgeRecogSolList(FridgeRecogSol fridgeRecogSol){
        fridgeRecogSolList.Add(fridgeRecogSol);
    }
    public void registParticleCollision(ParticleCollision particleCollision)
    {
        particleCollisionList.Add(particleCollision);
    }
    public void registDestructible(Destructible destructible)
    {
        destructibleList.Add(destructible);
    }

    public void RegistHint(UI_Manager_Hint hint){
        this.hint = hint;
    }

    public void ShowUI(){
        AllCheck();

        if(benzenPassCheck){
            benzenPass.Solve();
        }
        else{
            benzenPass.NotSolve();
        }

        if(correctPosPassCheck){
            correctPosPass.Solve();
        }
        else{
            correctPosPass.NotSolve();
        }

        if(flammabilityPassCheck){
            flammabilityPass.Solve();
        }
        else{
            flammabilityPass.NotSolve();
        }

        if(wasteFluidPassCheck){
            wasteFluidPass.Solve();
        }
        else{
            wasteFluidPass.NotSolve();
        }

        if(wrongWasteFluidPassCheck){
            wrongWasteFluidPass.Solve();
        }
        else{
            wrongWasteFluidPass.NotSolve();
        }

        if(!spillPassCheck){
            UI_Object spillUIObject = new UI_Object();
            spillUIObject.EducationType = "폐액처리";
            spillUIObject.EducationName = "바닥에 시약 흘림";
            spillUIObject.OX = "X";
            GameManager.Instance.UIManager.AddUI(ref spillUIObject);
        }

        if (!destructionPassCheck)
        {
            UI_Object destructionUIObject = new UI_Object();
            destructionUIObject.EducationType = "시약관리";
            destructionUIObject.EducationName = "시약병 깨짐";
            destructionUIObject.OX = "X";
            GameManager.Instance.UIManager.AddUI(ref destructionUIObject);
        }

    }

    public void PositionAllCheck(){
        BenzenPassCheck();
        CorrectPosPassCheck();
        FlammabilityPassCheck();
    }

    public void WasteAllCheck(){
        WasteFluidPassCheck();
        WrongWasteFluidPassCheck();
        SpillPassCheck();
        DestructionPassCheck();
    }

    public void AllCheck(){
        PositionAllCheck();
        WasteAllCheck();
    }

    public void BenzenPassCheck(){
        foreach(FridgeRecogSol item in fridgeRecogSolList){
            if (!item._CorrectPosPass && !item.benzenPass){
                //벤젠 통과 못함
                benzenPassCheck = false;
                return;
            }
        }
        benzenPassCheck = true;
        Debug.Log("BenzenPassCheck : " + benzenPassCheck);
    }

    public void CorrectPosPassCheck(){
        foreach(FridgeRecogSol item in fridgeRecogSolList){
            if (!item._CorrectPosPass){
                //시약 구분 못함
                correctPosPassCheck = false;
                hint.UpdateText1UI(false);
                return;
            }
        }

        correctPosPassCheck = true;
        Debug.Log("CorrectPosPassCheck : " + correctPosPassCheck);
        hint.UpdateText1UI(true);
    }

    public void FlammabilityPassCheck(){
        foreach(FridgeRecogSol item in fridgeRecogSolList){
            if (!item._CorrectPosPass && !item.flammabilityPass)
            {
                //인화성 통과 못함
                flammabilityPassCheck = false;
                return;
            }
        }

        flammabilityPassCheck = true;
        Debug.Log("FlammabilityPassCheck : " + flammabilityPassCheck);
    }

    public void WasteFluidPassCheck()
    {
        foreach (ParticleCollision item in particleCollisionList)
        {
            if (!item.ExpirationDate && !item.wasteFluidPass)
            {
                //폐액처리 통과 못함
                wasteFluidPassCheck = false;
                hint.UpdateText2UI(false);
                return;
            }
        }

        wasteFluidPassCheck = true;
        Debug.Log("WasteFluidPassCheck : " + wasteFluidPassCheck);
        hint.UpdateText2UI(true);
    }
    public void WrongWasteFluidPassCheck()
    {
        foreach (ParticleCollision item in particleCollisionList)
        {
            if (!item.wrongWasteFluidPass)
            {
                //폐액처리 통과 못함
                wrongWasteFluidPassCheck = false;
                return;
            }
        }

        wrongWasteFluidPassCheck = true;
        Debug.Log("WrongWasteFluidPassCheck : " + wrongWasteFluidPassCheck);
    }

    public void SpillPassCheck()
    {
        foreach (ParticleCollision item in particleCollisionList)
        {
            if (!item.spillPass)
            {
                //폐액처리 통과 못함
                spillPassCheck = false;
                return;
            }
        }

        spillPassCheck = true;
        Debug.Log("SpillPassCheck : " + spillPassCheck);
    }
    public void DestructionPassCheck()
    {
        foreach (Destructible item in destructibleList)
        {
            if (!item.destructiblePass)
            {
                //폐액처리 통과 못함
                destructionPassCheck = false;
                return;
            }
        }

        destructionPassCheck = true;
        Debug.Log("DestructionPassCheck : " + destructionPassCheck);
    }

    // 마지막 UI에는 딱 한번만 체크해서 띄어주면되는데
    // 힌트 실시간...
}