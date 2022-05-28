using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionSY : MonoBehaviour
{
    public bool wrongWasteFluidPass = true;
    public bool ExpirationDate = true;
    public bool wasteFluidPass = true;
    private int particleCnt = 0;
    private int spillParticleCnt = 0;
    public bool spillPass = true;
    public bool allPass = false;

    private void Awake() {
        GameManager.Instance.BottleManager.registParticleCollision(this);
    }

    private void Start()
    {
        if (!ExpirationDate)
        {
            bool tmp1 = wasteFluidPass;
            wasteFluidPass = false;

            if (tmp1 != wasteFluidPass)
            {
                GameManager.Instance.BottleManager.WasteFluidPassCheck();
                Debug.Log("WasteFluidPassCheck  : " + wasteFluidPass);
            }
        }
    }

    /*private void Update()
    {
        Debug.Log("particleCnt : " + particleCnt);
        Debug.Log("spillParticleCnt : " + spillParticleCnt);
    }*/

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("CheckParticle"))
        {
            //Debug.Log("+++++++ name : " + other.name + " tag : " + other.tag);
            if (!other.transform.parent.CompareTag(transform.tag))
            {
                bool tmp1 = wrongWasteFluidPass;
                wrongWasteFluidPass = false;

                if (tmp1 != wrongWasteFluidPass)
                {
                    GameManager.Instance.BottleManager.WrongWasteFluidPassCheck();
                    Debug.Log("WrongWasteFluidPassCheck  : " + wrongWasteFluidPass);
                }
            }
            else if(!ExpirationDate && !wasteFluidPass)
            {
                particleCnt++;
                //Debug.Log("particleCnt: " + particleCnt);

                if (particleCnt > 300)
                {
                    bool tmp1 = wasteFluidPass;
                    wasteFluidPass = true;

                    if (tmp1 != wasteFluidPass)
                    {
                        GameManager.Instance.BottleManager.WasteFluidPassCheck();
                        Debug.Log("WrongWasteFluidPassCheck  : " + wrongWasteFluidPass);
                    }

                    GetComponentInParent<FridgeRecogSol>().allPass = true;
                    GameManager.Instance.BottleManager.PositionAllCheck();
                }
            }
        }
        else if(spillPass)
        {
            if(other.layer != LayerMask.NameToLayer("Default"))
            {
                spillParticleCnt++;
            }
            if(spillParticleCnt > 70)
            {
                bool tmp1 = spillPass;
                spillPass = false;

                if (tmp1 != spillPass)
                {
                    GameManager.Instance.BottleManager.SpillPassCheck();
                    Debug.Log("SpillPassCheck  : " + spillPass);
                }
            }
        }
        //Debug.Log("particleCnt : " + particleCnt +  ", other : " + other.name);
        //Debug.Log("spillParticleCnt : " + spillParticleCnt);
    }
}
