using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commander : MonoBehaviour
{
    public static Commander instance { get; private set; }
    public int[] letters = new int[26];
    public Transform inventoryPanel;
    public Sprite[] lettersSprites;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        updateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCountOfLetter(char letter)
    {
        char lowerLetter = char.ToLower(letter);
        int index = lowerLetter - 'a';
        if (index >= 0 && index < letters.Length)
        {
            return letters[index];
        }
        else
        {
            return 0;
        }
    }

    public void updateInventory()
    {
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }
        inventoryPanel.DetachChildren();
        for (int i = 0; i < letters.Length; i++)
        {
            int count = getCountOfLetter((char)('a' + i));
            for (int j = 0; j < count; j++)
            {
                GameObject g = new GameObject();
                Image img = g.AddComponent<Image>();
                img.sprite = lettersSprites[i];
                g.GetComponent<RectTransform>().SetParent(inventoryPanel);
            }
        }
    }
}
