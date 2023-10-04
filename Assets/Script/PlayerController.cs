using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject nearbyItem;
    private bool canPickUp = false;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (canPickUp && Input.GetKeyDown(KeyCode.E) && nearbyItem != null)
        {
            PickUpItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            nearbyItem = other.gameObject;
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            nearbyItem = null;
            canPickUp = false;
        }
    }

    void PickUpItem()
    {
        // アイテムの取得処理をここに記述
        Debug.Log("アイテムを取得しました: " + nearbyItem.name);
        Destroy(nearbyItem);
        nearbyItem = null;
        canPickUp = false;
    }
}
