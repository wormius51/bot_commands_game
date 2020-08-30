using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Command : MonoBehaviour
{
    public string commandString;
    public UnityEvent onActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tryActivate()
    {
        if (Commander.instance == null)
            return;
        Commander commander = Commander.instance;
        foreach (char letter in commandString)
        {
            char lowerLetter = char.ToLower(letter);
            int index = lowerLetter - 'a';
            if (commander.letters[index] == 0)
                return;
        }
        foreach (char letter in commandString)
        {
            char lowerLetter = char.ToLower(letter);
            int index = lowerLetter - 'a';
            commander.letters[index]--;  
        }
        onActivate.Invoke();
        return;
    }
}
