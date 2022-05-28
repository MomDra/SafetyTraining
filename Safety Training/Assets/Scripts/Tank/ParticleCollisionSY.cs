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
            wasteFluidPass = false;
            GameManager.Instance.BottleManager.WasteFluidPassCheck();
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
                wrongWasteFluidPass = false;
                GameManager.Instance.BottleManager.WrongWasteFluidPassCheck = false;
            }
            else if(!ExpirationDate && !wasteFluidPass)
            {
                particleCnt++;
                //Debug.Log("particleCnt: " + particleCnt);

                if (particleCnt > 300)
                {
                    wasteFluidPass = true;

                    GameManager.Instance.BottleManager.WasteFluidPassCheck();
                    GetComponentInParent<FridgeRecogSol>().allPass = true;
                    GameManager.Instance.BottleManager.PositionAllCheck();
                }
            }
        }
        else if(spillPass)
        {
            if(other.layer != LayerMask.NameToLayer("Waste"))
            {
                spillParticleCnt++;
            }
            
            if(spillParticleCnt > 70)
            {
                spillPass = false;
                GameManager.Instance.BottleManager.SpillPassCheck = false;
            }
        }
        //Debug.Log("particleCnt : " + particleCnt +  ", other : " + other.name);
        //Debug.Log("spillParticleCnt : " + spillParticleCnt);
    }
}
