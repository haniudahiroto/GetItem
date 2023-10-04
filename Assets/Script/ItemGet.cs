using UnityEngine;

public class ItemGet : MonoBehaviour
{
    public string itemName = "アイテム名";

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

