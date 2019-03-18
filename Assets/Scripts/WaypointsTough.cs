using UnityEngine;

public class WaypointsTough : MonoBehaviour {

    public static Transform[] points; //array for waypoints

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    void OnDrawGizmos()
    {
        if (points.Length > 0)
            for (int i = 0; i < points.Length; i++)
            {
                Gizmos.DrawSphere(points[i].position, 2);
                if (i < points.Length - 1)
                    Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
        
    }
}
