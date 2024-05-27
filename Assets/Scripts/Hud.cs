
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
        if (txtName != null)
            txtName.text = "Player " + health.netIdentity.netId;
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
        gameObject.SetActive(true);
    }
    void Update()
    {
        if (targetHealth == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetHealth.transform.position);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out localPoint);
        rectTransform.localPosition = localPoint + offset;


        if (slider != null)
            slider.value = targetHealth.current / targetHealth.max;
    }

}
