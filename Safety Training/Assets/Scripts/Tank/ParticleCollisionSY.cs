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
    private int wrongParticleCnt = 0;
    private int CNT;
    public bool spillPass = true;
    bool isLeak = false;

    AudioSource source;

    private void Awake() {
        GameManager.Instance.BottleManager.registParticleCollision(this);
        source = GetComponent<AudioSource>();
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
                if (wrongWasteFluidPass)
                {
                    wrongWasteFluidPass = false;
                    GameManager.Instance.BottleManager.WrongWasteFluidPassCheck = false;
                }
                
            }
            else if(!ExpirationDate && !wasteFluidPass)
            {
                particleCnt++;
                //Debug.Log("particleCnt: " + particleCnt);

                if (particleCnt > 180)
                {
                    wasteFluidPass = true;

                    GameManager.Instance.BottleManager.WasteFluidPassCheck();
                    
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

        if (!source.isPlaying) source.Play();

        Debug.Log("particleCnt : " + particleCnt + "spillParticleCnt : " + spillParticleCnt + ", other : " + other.name);
        //Debug.Log("spillParticleCnt : " + spillParticleCnt);

        CNT++;
        Debug.Log("cnt : " + CNT);
        if (CNT > 330 && !isLeak)
        {
            isLeak = true;
            GetComponentInParent<FridgeRecogSol>().AllPass = true;
            GameManager.Instance.BottleManager.PositionAllCheck();
        }
    }
}
