using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BottleManager
{
    private bool benzenPassCheck;
    private bool correctPosPassCheck;
    //public bool _CorrectPosPassCheck {get => correctPosPassCheck;}
    private bool flammabilityPassCheck;
    private bool wasteFluidPassCheck;
    //public bool _WasteFluidPassCheck {get => wasteFluidPassCheck;}



    // 단발성
    bool wrongWasteFluidPassCheckTrigger;
    private bool wrongWasteFluidPassCheck;
    public bool WrongWasteFluidPassCheck { get => wrongWasteFluidPassCheck; 
        set
        {
            wrongWasteFluidPassCheck = value;
            wrongWasteFluidPassCheckTrigger = true;
        }
    }

    private bool spillPassCheck;
    public bool SpillPassCheck { get => spillPassCheck; set => spillPassCheck = value; }

    private bool destructionPassCheck;
    public bool DestructionPassCheck { get => destructionPassCheck; set => destructionPassCheck = value; }

    private bool directSunlightPassCheck;
    public bool DirectSunlightPassCheck { get => directSunlightPassCheck; set => directSunlightPassCheck = value; }

    public Task benzenPass;
    public Task correctPosPass;
    public Task flammabilityPass;
    public Task wasteFluidPass;
    public Task wrongWasteFluidPass;
    public Task directSunlightPass;

    // 재시작시 초기화
    List<FridgeRecogSol> fridgeRecogSolList;
    List<ParticleCollisionSY> particleCollisionList;

    UI_Manager_Hint hint;

    public void Init()
    {
        benzenPassCheck = false;
        correctPosPassCheck = false;
        flammabilityPassCheck = false;
        wasteFluidPassCheck = false;
        wrongWasteFluidPassCheck = true;
        spillPassCheck = true;
        destructionPassCheck = true;
        directSunlightPassCheck = false;
        fridgeRecogSolList = new List<FridgeRecogSol>();
        particleCollisionList = new List<ParticleCollisionSY>();
    }

    public void registFridgeRecogSolList(FridgeRecogSol fridgeRecogSol){
        fridgeRecogSolList.Add(fridgeRecogSol);
    }
    public void registParticleCollision(ParticleCollisionSY particleCollision)
    {
        particleCollisionList.Add(particleCollision);
    }

    public void RegistHint(UI_Manager_Hint hint){
        this.hint = hint;
    }

    public void ShowUI(){
        AllCheck();

        benzenPass.UI_INFO.OX = benzenPassCheck ? "O" : "X";
        correctPosPass.UI_INFO.OX = correctPosPassCheck ? "O" : "X";
        flammabilityPass.UI_INFO.OX = flammabilityPassCheck ? "O" : "X";
        wasteFluidPass.UI_INFO.OX = wasteFluidPassCheck ? "O" : "X";
        wrongWasteFluidPass.UI_INFO.OX = wrongWasteFluidPassCheck ? "O" : "X";
        directSunlightPass.UI_INFO.OX = directSunlightPassCheck ? "O" : "X";

        GameManager.Instance.UIManager.AddUI(ref benzenPass.UI_INFO);
        GameManager.Instance.UIManager.AddUI(ref correctPosPass.UI_INFO);
        GameManager.Instance.UIManager.AddUI(ref flammabilityPass.UI_INFO);
        GameManager.Instance.UIManager.AddUI(ref wasteFluidPass.UI_INFO);
        if(wrongWasteFluidPassCheckTrigger) GameManager.Instance.UIManager.AddUI(ref wrongWasteFluidPass.UI_INFO);
        GameManager.Instance.UIManager.AddUI(ref directSunlightPass.UI_INFO);

        if (!spillPassCheck){
            UI_Object spillUIObject = ScriptableObject.CreateInstance<UI_Object>();
            spillUIObject.EducationType = "폐액처리";
            spillUIObject.EducationName = "바닥에 시약 흘림";
            spillUIObject.OX = "X";
            GameManager.Instance.UIManager.AddUI(ref spillUIObject);
        }

        if (!destructionPassCheck)
        {
            UI_Object destructionUIObject = ScriptableObject.CreateInstance<UI_Object>();
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

                Debug.Log("누구냐 너는!: " + item.name);
                return;
            }
        }

        correctPosPassCheck = true;
        Debug.Log("CorrectPosPassCheck : " + correctPosPassCheck);
        hint.UpdateText1UI(true);
        if (wasteFluidPassCheck) GameManager.Instance.EndGame();
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
        foreach (ParticleCollisionSY item in particleCollisionList)
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
        if (correctPosPassCheck) GameManager.Instance.EndGame();
    }

    public void DestroyList(FridgeRecogSol fridgeRecogSol, ParticleCollisionSY particleCollision)
    {
        foreach (FridgeRecogSol item in fridgeRecogSolList)
        {
            if(item == fridgeRecogSol){
                fridgeRecogSolList.Remove(item);
                Debug.Log("FridgeRecogSol 삭제됨!!!");
                break;
            }
        }

        foreach(ParticleCollisionSY item in particleCollisionList){
            if(item == particleCollision){
                particleCollisionList.Remove(item);
                Debug.Log("ParticleCollision 삭제됨!!!");
                break;
            }
        }
        AllCheck();
    }

    // 마지막 UI에는 딱 한번만 체크해서 띄어주면되는데
    // 힌트 실시간...
}