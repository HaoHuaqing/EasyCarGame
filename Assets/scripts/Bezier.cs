using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(LineRenderer))]
public class Bezier : MonoBehaviour
{
    public Transform[] controlPoints;
    public LineRenderer lineRenderer;

    public GameObject RandomPoint;
    public GameObject[] CreatPoint;
    public Transform startPosition;
    Vector3 uppoint = new Vector3(0, 10, 0);
    public static Vector3[] pixel = new Vector3[60000];
    public static float[] Rand = new float[100];

    private int curveCount = 0;
    private int layerOrder = 0;
    private int SEGMENT_COUNT = 200;
    bool roadmove = true;

    void Start()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        lineRenderer.sortingLayerID = layerOrder;
        curveCount = (int)controlPoints.Length / 2;

        for (int i = 1; i < 99; i = i + 2)
        {
            //crear random point to draw curve
            Rand[i] = 4 * (Random.value * 2 - 1);
            Vector3 RandX = new Vector3(Rand[i], 0, 0);
            CreatPoint[i] = Instantiate(RandomPoint, startPosition.transform.position + i * uppoint + RandX, Quaternion.identity) as GameObject;
            CreatPoint[i + 1] = Instantiate(RandomPoint, startPosition.transform.position + (i + 1) * uppoint, Quaternion.identity) as GameObject;
            controlPoints[i] = CreatPoint[i].transform;
            controlPoints[i + 1] = CreatPoint[i + 1].transform;
        }
        
        DrawCurve();
    }

    void Update()
    {

        

    }

    void DrawCurve()
    {

        for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 2;
                pixel[(j * SEGMENT_COUNT) + (i - 1)] = CalculateCubicBezierPoint(t, controlPoints[nodeIndex].position, controlPoints[nodeIndex + 1].position, controlPoints[nodeIndex + 2].position);
                lineRenderer.SetVertexCount(((j * SEGMENT_COUNT) + i));
                lineRenderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel[(j * SEGMENT_COUNT) + (i - 1)]);
            }

        }
    }

    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }

}
