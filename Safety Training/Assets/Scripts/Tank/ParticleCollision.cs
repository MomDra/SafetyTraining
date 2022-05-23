using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public bool wrongWasteFluidPass = true;
    public bool ExpirationDate = true;
    public bool wasteFluidPass = true;
    private int particleCnt = 0;
    private int spillParticleCnt = 0;
    public bool spillPass = true;
    public bool allPass = false;

    private void Start()
    {
        if (!ExpirationDate)
        {
            bool tmp1 = wasteFluidPass;
            wasteFluidPass = false;

            if (tmp1 != wasteFluidPass)
            {
                GameManager.Instance.BottleManager.WasteFluidPassCheck();
            }
        }
    }

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
                }
            }
            else if(!ExpirationDate && wasteFluidPass != false)
            {
                particleCnt++;
                Debug.Log("particleCnt: " + particleCnt);

                if (particleCnt > 300)
                {
                    bool tmp1 = wasteFluidPass;
                    wasteFluidPass = true;

                    if (tmp1 != wasteFluidPass)
                    {
                        GameManager.Instance.BottleManager.WasteFluidPassCheck();
                    }
                }
            }
        }
        else if(spillPass)
        {
            spillParticleCnt++;
            if(spillParticleCnt > 25)
            {
                bool tmp1 = spillPass;
                spillPass = false;

                if (tmp1 != spillPass)
                {
                    GameManager.Instance.BottleManager.SpillPassCheck();
                }
            }
        }

    }
}
