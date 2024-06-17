using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public DummyLogic healthScript; // Drag the Health component here in the inspector
    public RectTransform healthBarTransform;
    public Vector3 offset = new Vector3(0, 2, 0); // Adjust as needed

    void Update()
    {
        Vector3 worldPos = healthScript.transform.position + offset;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        healthBarTransform.position = screenPos;
        float healthPercentage = healthScript.currentHealth / healthScript.maxHealth;
        healthBarTransform.localScale = new Vector3(healthPercentage, 1, 1);
    }
}