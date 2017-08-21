using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Updates the MessageText UI via UnityEvent messaging from the player script.
public class MessageController : MonoBehaviour
{
    private Text messageText;
    private string[] messages = { "Go! Go! Go!", "Nice get!", "Gibs me dat!", "You da man!", "A winrar is you!" };
	private int msgNum = 0;

    // Use this for initialization
    void Start()
    {
        messageText = GetComponent<Text>();
        setMessage(msgNum);
    }

    // Invoked by the player when trigger-colliding with a pickup.
    public void updateMessageEvent()
    {
        setMessage(++msgNum);
    }

    void setMessage(int index)
    {
        messageText.text = messages[index];
    }
}
