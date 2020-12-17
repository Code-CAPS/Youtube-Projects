using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthMax = 10.0f;
    public float healthCurrent = 10.0f;

    public void Damage(float damage)
    {
        healthCurrent = healthCurrent - damage;
        healthCurrent = Mathf.Clamp(healthCurrent, 0.0f, healthMax);
    }
}
