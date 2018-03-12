using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour {


    public Color rayColor = Color.white;
    public List<Transform> pathPoints = new List<Transform>();
    Transform[] transforms;


    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        transforms = GetComponentsInChildren<Transform>();
        pathPoints.Clear();

        foreach (Transform path in transforms) {

            if (path != this.transform) {

                pathPoints.Add(path);

            }

        }

        for (int i = 0; i < pathPoints.Count; i++) {

            Vector3 position = pathPoints[i].position;
            if (i > 0) {
                Vector3 previous = pathPoints[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawSphere(position, 0.3f);
            }
        }
    }
}
