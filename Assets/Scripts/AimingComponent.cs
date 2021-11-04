using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class AimingComponent : MonoBehaviour
{
    [SerializeField] private PlateComponent target;
    [SerializeField] private AimIndicator indicator;
    [SerializeField] private Image boundsImage;
    [SerializeField] private float baseAimTime;
    private float currentAim;
    [SerializeField] private UnityEvent OnAimComplite;
    private Camera cam;

    private Coroutine AimCorutine;
    public bool StayOnBounds(Vector3 screenPosition, Image boundsImage)
    {
        Vector3 boundsOffset = new Vector2(boundsImage.sprite.rect.width, boundsImage.sprite.rect.height);

        if (screenPosition.x < (boundsImage.rectTransform.position + boundsOffset).x && screenPosition.x > (boundsImage.rectTransform.position - boundsOffset).x &&
            screenPosition.y < (boundsImage.rectTransform.position + boundsOffset).y && screenPosition.y > (boundsImage.rectTransform.position - boundsOffset).y)
        {
            return true;
        }
        else return false;
    }

    public void SetTarget(PlateComponent target)
    {
        currentAim = 0;
        this.target = target;
    }
    
    public void RemoveTarget()
    {
        Destroy(target.gameObject);
    }
    
    public void LuckyShoot()
    {
        float rand = Random.Range(0f, 1f);
        
        if (rand < currentAim)
        {
            OnAimComplite?.Invoke();
            RemoveTarget();
        }
        else
        {
            OnAimComplite?.Invoke();
        }

    }

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
       
        
        if (target == null)
        {
            indicator.UpdateProgress(0);
            return;
        }
        
        Vector3 targetPos = cam.WorldToScreenPoint(target.position);

        if (StayOnBounds(targetPos, boundsImage))
        {
            if(AimCorutine == null)
            {
                AimCorutine = StartCoroutine(AimFilling((int)Vector3.Distance(transform.position, target.position) / 5));
            }
        }
        else
        {
            indicator.UpdateProgress(0);
            StopAllCoroutines();
            AimCorutine = null;
        }
    }

    
    
    private IEnumerator AimFilling(int timeMultiplayer)
    {
        float amount = baseAimTime * timeMultiplayer;
        float currentAmount = 0;
        while (currentAmount < amount)
        {
            if (target == null)
            {
                OnAimComplite?.Invoke();
                yield break;
            }
            currentAim = currentAmount / amount;
            indicator.UpdateProgress(currentAmount / amount);
            currentAmount += Time.deltaTime;
            yield return null;
        }

        OnAimComplite?.Invoke();
        RemoveTarget();
    }
}
