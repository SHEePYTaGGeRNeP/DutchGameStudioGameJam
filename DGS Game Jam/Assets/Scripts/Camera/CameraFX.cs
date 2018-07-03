using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFX : MonoBehaviour {

    [Header("Knockback")]
    [SerializeField]
    private bool playKnockbackOnStart;
    [SerializeField]
    private float knockbackInstensity, knockbackSpeed;

    private Vector3 localStartPos;
    private Coroutine knockback;
    private bool isKnockedBack = false;

    [Header("Camera Shake")]
    [SerializeField]
    private bool screenShakeOnStart;
    [SerializeField]
    private bool smooth;
    [SerializeField]
    private float shakeAmount, shakeDuration, smoothAmount = 5;

    private float shakePercentage, startAmount, startDuration;
    private bool isShaking = false;
    private Coroutine cameraShake;

    private void Start()
    {
        localStartPos = transform.localPosition;
        if (playKnockbackOnStart) KnockbackCamera();
        if (screenShakeOnStart) ShakeCamera();
    }

    public void KnockbackCamera()
    {
        KnockbackCamera(knockbackInstensity, knockbackSpeed, -transform.forward);
    }

    public void KnockbackCamera(Vector3 direction)
    {
        KnockbackCamera(knockbackInstensity, knockbackSpeed, direction);
    }

    public void KnockbackCamera(float intensity, float speed, Vector3 direction)
    {
        if (isKnockedBack) StopCoroutine(knockback);
        knockback = StartCoroutine(Knockback(intensity, speed, direction));
    }

    private IEnumerator Knockback(float intensity, float speed, Vector3 direction)
    {
        isKnockedBack = true;
        Vector3 targetPos = localStartPos + direction * knockbackInstensity;
        while(transform.localPosition != targetPos)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * speed);
            yield return null;
        }
        while(transform.position != localStartPos)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, localStartPos, Time.deltaTime * (speed / 2));
            yield return null;
        }
        isKnockedBack = false;
    }

    public void ShakeCamera()
    {
        ShakeCamera(shakeAmount, shakeDuration, smooth, smoothAmount);
    }

    public void ShakeCamera(float amount, float duration, bool smooth, float smoothAmount)
    {
        if(cameraShake != null) StopCoroutine(cameraShake);
        cameraShake = StartCoroutine(Shake(amount, duration, smooth, smoothAmount));
    }


    IEnumerator Shake(float amount, float duration, bool smooth, float smoothAmount)
    {
        isShaking = true;
        float shakeAmount = amount;
        float shakeDuration = duration;
        startAmount = shakeAmount;
        startDuration = shakeDuration;
        Quaternion origionalRotation = transform.localRotation;

        while (shakeDuration > 0.01f)
        {
            Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount;
            rotationAmount.z = 0;

            shakePercentage = shakeDuration / startDuration;

            shakeAmount = startAmount * shakePercentage;
            shakeDuration = Mathf.Lerp(shakeDuration, 0, Time.deltaTime);


            if (smooth)
                transform.localRotation = Quaternion.Lerp(origionalRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothAmount);
            else
                transform.localRotation = origionalRotation * Quaternion.Euler(rotationAmount);

            yield return null;
        }
        transform.localRotation = origionalRotation;
        isShaking = false;
    }
}
