using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExpand : MonoBehaviour
{
    IEnumerator coroutine;

    bool isExtinguished;


    bool isBig;

    private void Start()
    {
        coroutine = ExpandFireCoroutine();
        StartCoroutine(coroutine);

        isBig = transform.position.y > -8f ? false : true;
    }

    IEnumerator ExpandFireCoroutine()
    {
        yield return new WaitForSeconds(10f);

        Vector3 pos;

        if (isBig)
        {
            while (true)
            {
                Vector2 dir = Random.insideUnitCircle;
                Vector3 dir3 = new Vector3(dir.x, 0f, dir.y);

                pos = transform.position + dir3.normalized * 3;

                if (pos.x < 13f && pos.x > -1.6f && pos.z > -15.6f && pos.z < -8f)
                {
                    break;
                }
            }
            
        }
        else
        {
            while (true)
            {
                Vector2 dir = Random.insideUnitCircle;
                Vector3 dir3 = new Vector3(dir.x, 0f, dir.y);

                pos = transform.position + dir3.normalized * 3;

                if (pos.x < 3.6f && pos.x > -1.6f && pos.z > -8f && pos.z < -0.55f)
                {
                    break;
                }
            }
        }

        GameManager.Instance.EffectManager.MakeFireEffect(pos);
        Debug.Log("ºÒ ¹øÁü");

        StartCoroutine(ExpandFireCoroutine());
    }
}
