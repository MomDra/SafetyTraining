using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer lr;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public float vertexCnt = 10;

    // Start is called before the first frame update

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //point2.transform.position = new Vector3((point1.transform.position.x + point3.transform.position.x)/2, point1.transform.position.y, (point1.transform.position.z + point3.transform.position.z)/2);
        var pointList = new List<Vector3>();

        for(float ratio=0; ratio<=1; ratio += 1/vertexCnt)
        {
            var tanget1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tanget2 = Vector3.Lerp(point2.position, point3.position, ratio);
            var curve = Vector3.Lerp(tanget1, tanget2, ratio);

            pointList.Add(curve);
        }

        lr.positionCount = pointList.Count;
        lr.SetPositions(pointList.ToArray());
    }
}

