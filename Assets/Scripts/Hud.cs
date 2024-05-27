
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI txtName;
    private Health targetHealth;

    public Vector2 offset;
    private RectTransform rectTransform;
    private RectTransform parentRectTransform;
    public void Setup(Health health)
    {
        targetHealth = health;
        txtName.text = "Player " + health.netIdentity.netId;
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    void Update()
    {
        if (targetHealth == null) return;

        // Convert world position to screen position
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetHealth.transform.position);

        // Convert screen position to local position in the RectTransform
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out localPoint);
        rectTransform.localPosition = localPoint + offset;


        if (slider != null)
            slider.value = targetHealth.current / targetHealth.max;
    }

}
