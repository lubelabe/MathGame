using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateData : MonoBehaviour
{
    public static CalculateData Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public double VerticalSpeed(float initialSpeed, float initialAngle)
    {
        var angleRadians = initialAngle * (Math.PI / 180.0);
        var valueSin = Math.Sin(angleRadians);
        var result = initialSpeed * valueSin;
        return result;
    }

    public double TimeOfHeightMax(double verticalSpeed)
    {
        var timeTotal = verticalSpeed / 9.8;
        return timeTotal;
    }

    public double HorizontalSpeed(float initialSpeed, float initialAngle)
    {
        var angleRadians = initialAngle * (Math.PI / 180.0);
        var horizontalSpeed = initialSpeed * Math.Cos(angleRadians);
        return horizontalSpeed;
    }
    
    public double MaxHeight(double verticalSpeed, double timeHeight)
    {
        var heightMax = verticalSpeed * timeHeight - 0.5 * 9.8 * Math.Pow(timeHeight, 2);
        return heightMax;
    }

    public double TimeOfFly(double timeHeightMax)
    {
        var timeFly = 2 * timeHeightMax;
        return timeFly;
    }

    public double DistanceTotal(double horizontalSpeed, double timeOfFly)
    {
        var distanceTotal = horizontalSpeed * timeOfFly;
        return distanceTotal;
    }

    public double RampHeight(double verticalSpeed)
    {
        var rampHeight = Math.Pow(verticalSpeed, 2) / (2 * 9.81f);
        return rampHeight;
    }
}
