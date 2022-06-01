using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExpand : MonoBehaviour
{
    IEnumerator coroutine;

    bool isExtinguished;


    bool isBig;

    bool isTrigger;

    int makeCount;

    private void Start()
    {
        isBig = transform.position.z > -8f ? false : true;

        GameManager.Instance.EmergencyManager.NumFire++;

        coroutine = ExpandFireCoroutine();
        StartCoroutine(coroutine);
    }

    IEnumerator ExpandFireCoroutine()
    {
        yield return new WaitForSeconds(20f);

        Vector3 pos = transform.position;

        if (isBig)
        {
            int i = 0;

            for (i = 0; i < 100; i++)
            {
                Vector2 dir = Random.insideUnitCircle;
                Vector3 dir3 = new Vector3(dir.x, 0f, dir.y);

                pos = transform.position + dir3.normalized * 2;

                if ((pos.x < 13.84f && pos.x > 0.65f) && (pos.z > -14.93f && pos.z < -9.29f))
                {

                    isTrigger = true;
                    break;
                }

                i++;
            }
        }
        else
        {

            int i = 0;

            for(i = 0; i < 100; i++)
            {
                Vector2 dir = Random.insideUnitCircle;
                Vector3 dir3 = new Vector3(dir.x, 0f, dir.y);

                pos = transform.position + dir3.normalized * 2;

                if (pos.x < 4.35f && pos.x > 0.46f && pos.z > -7.25f && pos.z < -0.8f)
                {

                    isTrigger = true;
                    break;
                }

                i++;
            }
        }
        //Debug.Log("expand y : " + pos.y);
        pos.y = 0.1598936f;
        if (isTrigger)
            GameManager.Instance.EffectManager.MakeFireEffect(pos);
        isTrigger = false;
        StartCoroutine(ExpandFireCoroutine());

        /*
        if (isBig)
        {
            if (makeCount < 2)
            {
                StartCoroutine(ExpandFireCoroutine());
                makeCount++;
            }
        }
        else
        {
            if (makeCount < 1)
            {
                StartCoroutine(ExpandFireCoroutine());
                makeCount++;
            }
        }*/
    }
}
