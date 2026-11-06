using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGroundSaver : MonoBehaviour
{
    [SerializeField] private float SaveFrequency = 3f;

    public Vector3 SafeGroundLocation { get; private set; } = new Vector3(0f, 0f);

    private Coroutine safeGroundCoroutine;

    private PlayerController groundCheck;

    public void Start()
    {
        SafeGroundLocation = transform.position;

        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());

        groundCheck = GetComponent<PlayerController>();
    }

    private IEnumerator SaveGroundLocation()
    {
        float elapsedTime = 0f;
        while(elapsedTime < SaveFrequency)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (groundCheck.isGrounded())
        {
            SafeGroundLocation = transform.position;
        }
        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());


    }

    public void WarpPlayerToSafeGround()
    {
        transform.position = SafeGroundLocation;
    }
}
