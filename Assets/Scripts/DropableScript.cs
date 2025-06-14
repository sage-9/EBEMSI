// using UnityEngine;
// using UnityEngine.EventSystems;

// public class Drop : MonoBehaviour, IDropHandler
// {
//     public void OnDrop(PointerEventData eventData)
//     {
//         DraggableArtifact dragged = eventData.pointerDrag?.GetComponent<DraggableArtifact>();
//         if (dragged != null)
//         {
//             // Get the RectTransform of the drop slot (the current GameObject, which is your drop zone)
//             RectTransform slotRectTransform = this.GetComponent<RectTransform>();
//             RectTransform artifactRectTransform = dragged.GetComponent<RectTransform>();

//             // Calculate the scaling factor to fit the artifact into the drop slot width
//             float scaleFactor = slotRectTransform.rect.width / artifactRectTransform.rect.width;

//             // Instantiate the dropped artifact inside the slot
//             GameObject newArtifact = Instantiate(dragged.gameObject, this.transform);

//             // Adjust the scale to fit the drop slot width
//             newArtifact.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

//             // Calculate the center position inside the drop slot
//             // After scaling, calculate the new width and height of the artifact
//             float artifactWidth = newArtifact.GetComponent<RectTransform>().rect.width * scaleFactor;
//             float artifactHeight = newArtifact.GetComponent<RectTransform>().rect.height * scaleFactor;

//             // Set the local position to center the artifact within the drop slot
//             Vector3 localPosition = Vector3.zero;
//             localPosition.x = (slotRectTransform.rect.width - artifactWidth) / 2; // Center horizontally
//             localPosition.y = (slotRectTransform.rect.height - artifactHeight) / 2; // Center vertically

//             // Set the new artifact position inside the drop slot
//             newArtifact.transform.localPosition = localPosition;

//             // Disable blocking raycasts to ensure interactions work
//             newArtifact.GetComponent<CanvasGroup>().blocksRaycasts = true;
//         }
//     }
// }
using UnityEngine;

public class TimelineSlot : MonoBehaviour
{
    public string correctArtifactName;
    public bool isOccupied = false;
}
