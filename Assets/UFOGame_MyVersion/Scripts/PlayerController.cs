using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


// Custom UnityEvent: <int> parameter
// By default a UnityEvent in a Monobehaviour binds dynamically to a <void> function. This does not have to be the case as dynamic invocation of UnityEvents supports binding to functions with up to 4 arguments.
// By adding an instance of this to your class (instead of the base UnityEvent) it will allow the callback to bind dynamically to <int>> functions.
// This can then be invoked by calling the Invoke() function with an <int> as the argument.
[System.Serializable]
public class ScoreEvent : UnityEvent<int> { }

// Controls the UFO by handling input. Also handles collisions with pickups, and messaging the UI via UnityEvents.
public class PlayerController : MonoBehaviour
{

    public float speed;
    public ScoreEvent scoreEvent;
    public UnityEvent messageEvent;

    private Rigidbody2D rb2d;
    private AudioSource audioSource;
    private int score;              // Integer to store the number of pickups collected so far.

    // Use this for initialization
    void Start()
    {
        // Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        // Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        // Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(speed * new Vector2(moveHorizontal, moveVertical));
    }

    // OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            // ... then set the other object we just collided with to inactive.
            other.gameObject.SetActive(false);

            // Add one to the current value of our score variable.
            score += 1;

            // Update the currently displayed score by signalling the ScoreText UI with the new score.
            scoreEvent.Invoke(score);

            // Update the currently displayed message to the player by signalling the MessageText UI.
            messageEvent.Invoke();

			// Play a sound effect.
			audioSource.Play();
        }


    }

}