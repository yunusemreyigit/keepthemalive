using UnityEngine;
[RequireComponent(typeof(MovementMechanism))]
public class Battery : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxBatteryLevel = 0;
    [SerializeField] private float batteryLevel = 0;
    [Range(1, 20)]
    [SerializeField] private float batteryDrainMultiplier = 1;

    [Header("Interface")]
    public Transform battery;
    [SerializeField] private SpriteRenderer batterySprite;
    [SerializeField] private Color batteryColor;

    public bool isBatteryDead;
    private MovementMechanism movementMechanism;
    void Start()
    {
        batterySprite.color = batteryColor;
        movementMechanism = GetComponent<MovementMechanism>();
        batteryLevel = maxBatteryLevel;
    }

    void Update()
    {
        batteryLevel -= Time.deltaTime * batteryDrainMultiplier;
        batteryLevel = Mathf.Clamp(batteryLevel, 0, maxBatteryLevel);
        battery.localScale = new Vector3(1, batteryLevel / maxBatteryLevel, 1);
        BatteryDead();
    }
    void BatteryDead()
    {
        if (batteryLevel <= 0)
        {
            isBatteryDead = true;
            movementMechanism.canMove = false;
        }
        else
        {
            isBatteryDead = false;
            movementMechanism.canMove = true;
        }
    }
}
