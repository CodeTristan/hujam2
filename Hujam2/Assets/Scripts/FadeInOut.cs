using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image Dark;

    private void Start()
    {
        StartCoroutine(StartFade());
    }
    public void FadeWeek()
    {
        StartCoroutine(WeekFade());
    }

    private IEnumerator WeekFade()
    {
        Dark.gameObject.SetActive(true);
        StartCoroutine(FadeIn(Dark, 2));
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeOut(Dark, 2));
        yield return new WaitForSeconds(2);
        Dark.gameObject.SetActive(false);

    }
    private IEnumerator StartFade()
    {
        Dark.gameObject.SetActive(true);
        StartCoroutine(FadeOut(Dark, 2));
        yield return new WaitForSeconds(2);
        Dark.gameObject.SetActive(false);
    }

    private YieldInstruction Instruction = new YieldInstruction();
    public IEnumerator FadeOut(Image image,float time)
    {//general fade out effect for images
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < time)
        {
            yield return Instruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / time);
            image.color = c;
        }
    }

    public IEnumerator FadeIn(Image image,float time)
    {//general fade in effect for images
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < time)
        {
            yield return Instruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / time);
            image.color = c;
        }
    }
}
