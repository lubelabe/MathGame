using TMPro;
using UnityEngine;

public class ShowDataController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _dataToShow;

    public void ShowDataSkiGame()
    {
        var initialSpeed = ThrownController.Instance.LaunchSpeed;
        var initialAngle = ThrownController.Instance.LaunchAngle;

        var verticalSpeed = CalculateData.Instance.VerticalSpeed(initialSpeed, initialAngle);
        var timeHeightMax = CalculateData.Instance.TimeOfHeightMax(verticalSpeed);
        var horizontalSpeed = CalculateData.Instance.HorizontalSpeed(initialSpeed, initialAngle);
        var heightMax = CalculateData.Instance.MaxHeight(verticalSpeed, timeHeightMax);
        var timeOfFly = CalculateData.Instance.TimeOfFly(timeHeightMax);
        var distanceTotal = CalculateData.Instance.DistanceTotal(horizontalSpeed, timeOfFly);
        var heightRamp = CalculateData.Instance.RampHeight(verticalSpeed);
        
        _dataToShow[0].text = timeHeightMax.ToString("F");
        _dataToShow[1].text = verticalSpeed.ToString("F");
        _dataToShow[2].text = horizontalSpeed.ToString("F");
        _dataToShow[3].text = heightMax.ToString("F");
        _dataToShow[4].text = timeOfFly.ToString("F");
        _dataToShow[5].text = distanceTotal.ToString("F");
        _dataToShow[6].text = heightRamp.ToString("F");
    }
}
