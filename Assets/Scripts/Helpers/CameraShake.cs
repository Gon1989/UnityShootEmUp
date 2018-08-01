using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public static CameraShake instance;

    private Vector3 originalPos;
    private float timeAtCurrentFrame;
    private float timeAtLastFrame;
    private float fakeDelta;

    /*
     * call it from anywhere
      Ex: CameraShake.Shake(0.25f, 4f);
    */
    void Awake()
    {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {

        // Calculate a fake delta time, so we can Shake while game is paused.
        timeAtCurrentFrame = Time.realtimeSinceStartup;
        fakeDelta = timeAtCurrentFrame - timeAtLastFrame;
        timeAtLastFrame = timeAtCurrentFrame;

    }

    //function to shake screen with 2 arguments duration,amount
    public static void Shake (float duration, float amount) 
    {
        instance.originalPos = instance.gameObject.transform.localPosition;
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(duration, amount));
    }


    public IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (duration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;

            duration -= fakeDelta;

            yield return null;
        }

        transform.localPosition = originalPos;

    }



}
