using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PathCreator : MonoBehaviour {


    [SerializeField]
    public List<WayPoint> Waypoints;



    private void OnDrawGizmosSelected()
    {
        if (Waypoints == null) {

            return;
        }


        for (int i = 1; i< Waypoints.Count; i++) {

            Gizmos.color = Color.green;
            Gizmos.DrawLine(Waypoints[i].Position + transform.position, Waypoints[i - 1].Position + transform.position);
        }
    }
}


[System.Serializable]
public class WayPoint {

    [SerializeField]
    public Vector3 Position;

}
