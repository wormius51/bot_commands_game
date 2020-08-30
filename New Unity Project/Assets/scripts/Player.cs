using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed;
    public bool isWalking;
    public Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking) {
            Vector3 offset = Vector3.forward;
            switch (direction)
            {
                case Direction.down:
                    offset = Vector3.back;
                    break;
                case Direction.left:
                    offset = Vector3.left;
                    break;
                case Direction.right:
                    offset = Vector3.right;
                    break;
            }
            transform.position += offset * walkSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.transform.tag)
        {
            case "block":
                stop();
                break;
            case "letter":
                pickupLetter(other.transform.GetComponent<Letter>());
                break;
        }
    }

    private void stop()
    {
        Vector3 offset = Vector3.forward;
        switch (direction)
        {
            case Direction.down:
                offset = Vector3.back;
                break;
            case Direction.left:
                offset = Vector3.left;
                break;
            case Direction.right:
                offset = Vector3.right;
                break;
        }
        transform.position -= offset * walkSpeed * Time.deltaTime;
        isWalking = false;
    }

    private void pickupLetter(Letter letter)
    {
        char lowerLetter = char.ToLower(letter.character);
        int index = lowerLetter - 'a';
        Commander.instance.letters[index]++;
        Destroy(letter.gameObject);
    }

    public void walk(int direction)
    {
        walk((Direction)direction);
    }

    public void walk(Direction direction)
    {
        this.direction = direction;
        isWalking = true;
    }
}

public enum Direction
{
    up,
    down,
    left,
    right
}
