using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DraggableArtifact : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string artifactName;
    public Transform dragParent; // assign in inspector!

    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private bool isReturning = false; // to track return animation

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.position;
        startParent = rectTransform.parent;

        Debug.Log("Begin drag on: " + gameObject.name);

        canvasGroup.blocksRaycasts = false; // let raycasts pass through
        rectTransform.SetParent(dragParent); // move to drag parent (keeps it on top)
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isReturning)
        {
            rectTransform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        Debug.Log("End drag");

        GameObject target = eventData.pointerCurrentRaycast.gameObject;
        if (target != null)
        {
            Debug.Log("Dropped on: " + target.name);

            if (target.CompareTag("TimelineSlot"))
            {
                TimelineSlot slot = target.GetComponent<TimelineSlot>();
                if (slot != null)
                {
                    Debug.Log("Slot found, name match? " + (slot.correctArtifactName == artifactName));
                    Debug.Log("Slot occupied? " + slot.isOccupied);

                    if (slot.correctArtifactName == artifactName && !slot.isOccupied)
                    {
                        // Set the artifact as a child of the slot
                        rectTransform.SetParent(slot.transform);

                        // Resize and center using anchor approach
                        rectTransform.anchorMin = new Vector2(0.05f, 0.05f); // 5% padding on each side
                        rectTransform.anchorMax = new Vector2(0.95f, 0.95f); // 5% padding
                        rectTransform.offsetMin = Vector2.zero;
                        rectTransform.offsetMax = Vector2.zero;
                        rectTransform.localScale = Vector3.one; // ensure scale is normal

                        slot.isOccupied = true;

                        GameManager.Instance.ArtifactPlacedCorrectly();
                        Debug.Log("Artifact placed correctly and centered!");
                        return;
                    }
                }
            }
        }

        Debug.Log("Returning to original position");
        StartCoroutine(ReturnToStart());
    }

    private IEnumerator ReturnToStart()
    {
        isReturning = true;

        float duration = 0.3f; // 0.3 seconds
        float elapsed = 0f;
        Vector3 currentPos = rectTransform.position;

        while (elapsed < duration)
        {
            rectTransform.position = Vector3.Lerp(currentPos, startPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.position = startPosition;
        rectTransform.SetParent(startParent); // restore parent
        isReturning = false;
    }
}
