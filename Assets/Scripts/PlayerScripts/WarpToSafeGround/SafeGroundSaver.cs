using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGroundSaver : MonoBehaviour
{
    [SerializeField] private float SaveFrequency = 3f;

    public Vector3 Spawnpoint { get; set; } = new Vector3(1, 1, 0);

    public Vector3 SafeGroundLocation { get; private set; } = new Vector3(0f, 0f, 0f);

    private Coroutine safeGroundCoroutine;

    private PlayerController groundCheck;

    public void Start()
    {
        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());

        SafeGroundLocation = transform.position;

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
            Debug.Log("Saved ground location");
            SafeGroundLocation = transform.position;
        }
        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());


    }

    public void WarpPlayerToSafeGround()
    {
        //transform.position = SafeGroundLocation;
        transform.position = Spawnpoint;
        Debug.Log("Warped player");
    }
}
