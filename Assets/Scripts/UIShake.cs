using System.Collections;
using UnityEngine;

public class CanvasShaker : MonoBehaviour
{
    private RectTransform canvasTransform;
    private float duration = 0.25f;
    private float magnitude = 5f;

    private void Awake()
    {
        canvasTransform = GetComponent<RectTransform>(); 
    }

    public void ShakeCanvas()
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = canvasTransform.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-magnitude, magnitude); 

            canvasTransform.anchoredPosition = originalPosition + new Vector3(offsetX, 0, 0);
            elapsed += Time.deltaTime;

            yield return null; 
        }
        canvasTransform.anchoredPosition = originalPosition; 
    }
}