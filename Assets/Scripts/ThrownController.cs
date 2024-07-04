using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ThrownController : MonoBehaviour
{
    public static ThrownController Instance;
    
    public float LaunchAngle = 45f;
    public float LaunchSpeed = 10f;
    [SerializeField] private TrajectoryDrawer _trajectoryDrawer;
    [SerializeField] private Rigidbody _skierRigidbody;
    [SerializeField] private Slider _angleSlider;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private TextMeshProUGUI _textValueAngle;
    [SerializeField] private TextMeshProUGUI _textValueSpeed;

    private bool _isMoving;

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

    private void Start()
    {
        if (_angleSlider != null)
        {
            var valueInitialAngle = LaunchAngle / 100f;
            _textValueAngle.text = LaunchAngle.ToString("00");
            _angleSlider.value = valueInitialAngle;
            _angleSlider.onValueChanged.AddListener(delegate { UpdateAngle(); });
        }

        if (_speedSlider != null)
        {
            var valueInitalSpeed = LaunchSpeed / 100f;
            _textValueSpeed.text = LaunchSpeed.ToString("00");
            _speedSlider.value = valueInitalSpeed;
            _speedSlider.onValueChanged.AddListener(delegate { UpdateSpeed(); });
        }

        ShowTrajectory();
    }

    private void Update()
    {
        ShowTrajectory();

        if (_skierRigidbody.velocity.magnitude <= 0)
        {
            _isMoving = false;
        }
    }

    private void ShowTrajectory()
    {
        if (_isMoving)
        {
            return;
        }
        var launchAngleRad = Mathf.Deg2Rad * LaunchAngle;
        var launchDirection = new Vector3(Mathf.Cos(launchAngleRad), Mathf.Sin(launchAngleRad), 0);
        var launchVelocity = launchDirection * LaunchSpeed;

        if (_trajectoryDrawer != null)
        {
            _trajectoryDrawer.ShowTrajectory(transform.position, launchVelocity);
        }
    }

    public void LaunchObject()
    {
        _isMoving = true;
        
        _skierRigidbody.isKinematic = false;
        _skierRigidbody.useGravity = true;

        var launchAngleRad = Mathf.Deg2Rad * LaunchAngle;
        var launchDirection = new Vector3(Mathf.Cos(launchAngleRad), Mathf.Sin(launchAngleRad), 0);
        var launchVelocity = launchDirection * LaunchSpeed;

        _skierRigidbody.velocity = launchVelocity;
    }

    private void UpdateAngle()
    {
        var valueAngleFinal = (int)(_angleSlider.value * 100f);
        _textValueAngle.text = valueAngleFinal.ToString();
        LaunchAngle = valueAngleFinal;
    }

    private void UpdateSpeed()
    {
        var valueSpeedFinal = (int)(_speedSlider.value * 100f);
        _textValueSpeed.text = valueSpeedFinal.ToString();
        LaunchSpeed = valueSpeedFinal;
    }
}
