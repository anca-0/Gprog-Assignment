using UnityEngine;

public class PlayerRadarController : MonoBehaviour
{
    [SerializeField] private GameObject radarPulsePrefab;

    private PlayerControls playerControls;
    private GameObject currentPulse;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Movement.Pulse.performed += _ => ActivatePulse();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Movement.Pulse.performed -= _ => ActivatePulse();
    }

    private void ActivatePulse()
    {
        if (currentPulse != null)
        {
            return;
        }
        currentPulse = Instantiate(radarPulsePrefab, transform.position, Quaternion.identity);
        currentPulse.transform.SetParent(transform);
        Destroy(currentPulse, 1.5f);
    }

}
