using UnityEngine;

public class ItemGet : MonoBehaviour
{
    public string itemName = "ƒAƒCƒeƒ€–¼";

    void Start()
    {
        TextMesh itemNameText = GetComponentInChildren<TextMesh>();
        if (itemNameText != null)
        {
            itemNameText.text = itemName;
            itemNameText.gameObject.SetActive(false);
        }
    }
}

