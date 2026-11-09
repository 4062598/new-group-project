using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGroundSaver : MonoBehaviour
{
    [SerializeField] private float SaveFrequency = 20f;

    // test variable
    //public Vector3 Spawnpoint { get; set; } = new Vector3(30f,30f,30f);
    [SerializeField] public Transform Spawnpoint;
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
            Debug.Log(SafeGroundLocation);
            SafeGroundLocation = transform.position;
        }
        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());


    }

    public void WarpPlayerToSafeGround()
    {
        CharacterController controller = GetComponent<CharacterController>();
        controller.enabled = false;
        transform.position = SafeGroundLocation;
        Debug.Log("Warped player");
        Debug.Log(SafeGroundLocation);
        controller.enabled = true;
    }

    public void Respawn()
    {
        //warp player to set location, spawnpoint or checkpoint
        CharacterController controller = GetComponent<CharacterController>();
        controller.enabled = false;
        //set player position and rotation to spawnpoint
        transform.position = Spawnpoint.position;

        controller.enabled = true;
    }
}
