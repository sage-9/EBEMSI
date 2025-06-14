using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [Header("Carousel Settings")]
    [Tooltip("Total number of buttons.")]
    [SerializeField] private int totalButtons = 9;

    [Tooltip("Number of buttons visible in the viewport.")]
    [SerializeField] private int visibleButtons = 5;

    [Tooltip("Width of one button including spacing.")]
    [SerializeField] private float buttonWidth = 269.318f;

    [Header("UI Reference")]
    [Tooltip("The RectTransform that holds all the buttons (i.e., ButtonContainer).")]
    [SerializeField] private RectTransform levelPageRect;

    [Header("Tween Settings")]
    [Tooltip("Time it takes to tween between positions.")]
    [SerializeField] private float tweenTime = 0.3f;

    [Tooltip("Easing type for smooth tweening.")]
    [SerializeField] private LeanTweenType tweenType = LeanTweenType.easeOutCubic;

    [Header("Debug")]
    [SerializeField] private int currentIndex = 0; // the first visible button index (starts at 0)

    private Vector3 targetPos;

    private void Awake()
    {
        currentIndex = 0;
        targetPos = levelPageRect.localPosition;
    }

    public void Next()
    {
        if (currentIndex + visibleButtons < totalButtons)
        {
            currentIndex++;
            targetPos += new Vector3(-buttonWidth, 0f, 0f);
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            targetPos += new Vector3(buttonWidth, 0f, 0f);
            MovePage();
        }
    }

    private void MovePage()
    {
        LeanTween.cancel(levelPageRect.gameObject); // cancel previous tweens
        levelPageRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }
}
