using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    private Coroutine currentRoutine;

    public void PlayPath(List<Vector3> path)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(FollowPath(path));
    }
    private IEnumerator FollowPath(List<Vector3> path)
    {
        if (path == null || path.Count == 0)
            yield break;

        transform.position = path[0];

        for (int i = 1; i < path.Count; i++)
        {
            Vector3 target = path[i];

            while ((transform.position - target).sqrMagnitude > 0.001f)
            {
                Vector3 dir = (target - transform.position).normalized;

                if (dir.sqrMagnitude > 0.0001f)
                {
                    transform.up = dir;
                }

                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
