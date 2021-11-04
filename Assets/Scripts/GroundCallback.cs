using UnityEngine.UI;
using UnityEngine;

public class GroundCallback : MonoBehaviour
{
    
    [SerializeField] private Button spawnButton;

    public void OnCallback()
    {
        spawnButton.gameObject.SetActive( true);
    }
}
