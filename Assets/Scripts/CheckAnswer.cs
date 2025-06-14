using UnityEngine;

public class TimelineValidator : MonoBehaviour
{
    public Transform[] slots;
    public string[] correctOrder;

    public void CheckAnswer()
    {
        bool allCorrect = true;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount == 0 || slots[i].GetChild(0).name != correctOrder[i])
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            Debug.Log("Correct! 🎉");
            // Optional: show success popup
        }
        else
        {
            Debug.Log("Wrong! ❌ Try again.");
            // Optional: shake wrong items
        }
    }
}
