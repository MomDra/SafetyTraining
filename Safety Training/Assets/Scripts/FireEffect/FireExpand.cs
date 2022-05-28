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
        isBig = transform.position.y > -8f ? false : true;

        coroutine = ExpandFireCoroutine();
        StartCoroutine(coroutine);
    }

    IEnumerator ExpandFireCoroutine()
    {
        yield return new WaitForSeconds(10f);

        Vector3 pos = transform.position;

        if (isBig)
        {
            int i = 0;

            while (i < 10)
            {
                Vector2 dir = Random.insideUnitCircle;
                Vector3 dir3 = new Vector3(dir.x, 0f, dir.y);

                pos = transform.position + dir3.normalized * 3;



                if ((pos.x < 13f && pos.x > -1.6f) && (pos.z > -15.6f && pos.z < -8f))
                {
                    Debug.Log(i + ": break");
                    break;
                }

                i++;

                Debug.Log("i : " + i);
            }
            
        }
        else
        {
            int i = 0;

            while (i < 10)
            {
                Vector2 dir = Random.insideUnitCircle;
                Vector3 dir3 = new Vector3(dir.x, 0f, dir.y);

                pos = transform.position + dir3.normalized * 3;

                if (pos.x < 3.6f && pos.x > -1.6f && pos.z > -8f && pos.z < -0.55f)
                {
                    Debug.Log(i + ": small break");
                    break;
                }

                i++;
            }
        }

        GameManager.Instance.EffectManager.MakeFireEffect(pos);
        Debug.Log("ºÒ ¹øÁü ÁÂÇ¥ : " + pos);

        StartCoroutine(ExpandFireCoroutine());
    }
}
