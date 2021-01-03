using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingComponent : MonoBehaviour
{
    private PathFinding pathfinding;

    public GameObject floor;
    public float speed = 5;
    public float rotationSpeed = 2;
    private Quaternion lookRotation;
    private List<Vector3> path;

    // Start is called before the first frame update
    void Start()
    {
        pathfinding = new PathFinding(10*(int)floor.transform.localScale.x, 10 * (int)floor.transform.localScale.z, 10f, floor.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GoToMousePosition();
        }
    }

    public Vector3 GetMouseWorldPosition(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    private void GoToMousePosition()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition(Input.mousePosition, Camera.main);
        pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
        path = pathfinding.FindPath(this.transform.position, mouseWorldPosition);
        StopCoroutine("FollowPath");
        StartCoroutine("FollowPath");
    }

    IEnumerator FollowPath()
    {
        Vector3 waypoint = path[0];
        //Debug.Log(waypoint);
        int index = 0;

        while (true)
        {
            if (transform.position == waypoint)
            {
                index++;
                if (index >= path.Count)
                {
                    yield break;
                }
                waypoint = path[index];
                //Debug.Log(waypoint);
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            lookRotation = Quaternion.LookRotation(waypoint.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }
    }

}
