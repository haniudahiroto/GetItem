using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float pickupDistance = 2f; // アイテムを回収できる距離

    private GameObject nearbyItem;
    private bool canPickUp = false;
    public GameObject itemTextUI;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (canPickUp && Input.GetKeyDown(KeyCode.E) && nearbyItem != null)
        {
            float distanceToItem = Vector3.Distance(transform.position, nearbyItem.transform.position);
            if (distanceToItem <= pickupDistance)
            {
                PickUpItem();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            nearbyItem = other.gameObject;
            canPickUp = true;
            itemTextUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            nearbyItem = null;
            canPickUp = false;
            itemTextUI.SetActive(false);
        }
    }

    void PickUpItem()
    {
        Debug.Log("アイテムを取得しました: " + nearbyItem.name);
        Destroy(nearbyItem);
        nearbyItem = null;
        canPickUp = false;
        itemTextUI.SetActive(false);
    }
}
