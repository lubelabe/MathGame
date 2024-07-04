using UnityEngine;

public class TrajectoryDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _timeInterval = 0.1f;
    [SerializeField] private float _groundLevel = -30f;

    public void ShowTrajectory(Vector3 startPos, Vector3 initialVelocity)
    {
        var totalTime = CalculateTimeToGround(startPos, initialVelocity);
        
        var numPoints = Mathf.CeilToInt(totalTime / _timeInterval) + 1;
        var points = new Vector3[numPoints];
        _lineRenderer.positionCount = numPoints;

        for (var i = 0; i < numPoints; i++)
        {
            var time = i * _timeInterval;
            if (time > totalTime) time = totalTime;

            points[i] = CalculatePositionAtTime(startPos, initialVelocity, time);
        }

        _lineRenderer.SetPositions(points);
    }

    private Vector3 CalculatePositionAtTime(Vector3 startPos, Vector3 initialVelocity, float time)
    {
        var position = startPos + initialVelocity * time;
        position.y += 0.5f * Physics.gravity.y * Mathf.Pow(time, 2);
        return position;
    }

    private float CalculateTimeToGround(Vector3 startPos, Vector3 initialVelocity)
    {
        var gravity = Physics.gravity.y;
        var initialVelocityY = initialVelocity.y;
        var startY = startPos.y;

        var a = 0.5f * gravity;
        var b = initialVelocityY;
        var c = startY - _groundLevel;

        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            return 0;
        }

        var sqrtDiscriminant = Mathf.Sqrt(discriminant);
        var t1 = (-b + sqrtDiscriminant) / (2 * a);
        var t2 = (-b - sqrtDiscriminant) / (2 * a);

        var timeToGround = Mathf.Max(t1, t2);
        if (timeToGround < 0) timeToGround = Mathf.Min(t1, t2);

        return Mathf.Max(timeToGround, 0);
    }
}
