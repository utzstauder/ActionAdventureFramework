using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFadeController : MonoBehaviour
{
    [SerializeField] float fadeTime = 2f;

    Image image;
    Coroutine currentCoroutine;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FadeIn(fadeTime);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            FadeOut(fadeTime);
        }
    }

    void StopFade()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }

    public void FadeIn(float fadeInTime)
    {
        StopFade();
        currentCoroutine = StartCoroutine(FadeCoroutine(fadeInTime, 1f));
    }

    public void FadeOut(float fadeOutTime)
    {
        StopFade();
        currentCoroutine = StartCoroutine(FadeCoroutine(fadeOutTime, 0));
    }

    IEnumerator FadeCoroutine(float fadeTime, float targetAlpha)
    {
        float initialAlpha = image.color.a;

        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                Mathf.Lerp(initialAlpha, targetAlpha, t/fadeTime) // set alpha
                );
            yield return null;
        }

        image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                targetAlpha
                );

        currentCoroutine = null;
    }

}
