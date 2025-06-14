using UnityEngine;
using UnityEngine.UI; // For CanvasGroup (if using fade effect)

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int correctPlaced = 0;
    public int totalArtifacts = 0;

    [Header("Win UI Overlay")]
    public GameObject winOverlay; // Drag your WinOverlay panel here
    public CanvasGroup overlayCanvasGroup; // Optional: for fade-in effect

    void Awake()
    {
        Instance = this;
    }

    public void ArtifactPlacedCorrectly()
    {
        correctPlaced++;
        Debug.Log($"Correct artifacts placed: {correctPlaced}/{totalArtifacts}");

        if (correctPlaced >= totalArtifacts)
        {
            Debug.Log("🎉 You Win! 🎉");

            if (winOverlay != null)
            {
                winOverlay.SetActive(true); // Show the win overlay
            }

            // Optional fade-in effect
            if (overlayCanvasGroup != null)
            {
                StartCoroutine(FadeInOverlay());
            }
        }
    }

    private System.Collections.IEnumerator FadeInOverlay()
    {
        overlayCanvasGroup.alpha = 0;
        float duration = 1f; // fade in over 1 second
        float elapsed = 0f;

        while (elapsed < duration)
        {
            overlayCanvasGroup.alpha = Mathf.Lerp(0, 1, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        overlayCanvasGroup.alpha = 1;
    }
}
