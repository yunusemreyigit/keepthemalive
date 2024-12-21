using UnityEngine;
[RequireComponent(typeof(MovementMechanism))]
public class Battery : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxBatteryLevel = 0;
    [SerializeField] private float batteryLevel = 0;
    [Range(1, 20)]
    [SerializeField] private float batteryDrainRate = 1;

    [Header("Interface")]
    public Transform battery;
    [SerializeField] private SpriteRenderer batterySprite;
    [SerializeField] private Color batteryColor;

    private MovementMechanism movementMechanism;
    void Start()
    {
        batterySprite.color = batteryColor;
        maxBatteryLevel = 100;
        movementMechanism = GetComponent<MovementMechanism>();
        batteryLevel = maxBatteryLevel;
    }

    void Update()
    {
        batteryLevel -= Time.deltaTime * batteryDrainRate;
        batteryLevel = Mathf.Clamp(batteryLevel, 0, maxBatteryLevel);
        battery.localScale = new Vector3(1, batteryLevel / maxBatteryLevel, 1);
        if (batteryLevel <= 0)
        {
            movementMechanism.canMove = false;
        }
        else
        {
            movementMechanism.canMove = true;
        }
    }
}
