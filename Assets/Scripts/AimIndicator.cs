using UnityEngine.UI;
using UnityEngine;

public class AimIndicator : MonoBehaviour
{
    [SerializeField] Image progressImage;

    public void UpdateProgress(float normalizeValue)
    {
        progressImage.fillAmount = normalizeValue;
    }
}
