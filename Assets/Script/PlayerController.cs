using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // キャラクターの移動速度
    public float moveSpeed = 5f;

    // 近くのアイテムを格納する変数
    private GameObject nearbyItem;
    private bool canPickUp = false;

    public GameObject itemTextUI; // テキスト表示用のUIをアサイン

    void Update()
    {
        // プレイヤーの入力を受け取る
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 移動ベクトルを計算し、キャラクターを移動させる
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // アイテムを拾う条件をチェック
        if (canPickUp && Input.GetKeyDown(KeyCode.E) && nearbyItem != null)
        {
            // アイテムを拾う処理を実行
            PickUpItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 他のコライダーとの衝突時に呼ばれる
        if (other.CompareTag("Item"))
        {
            // 近くにアイテムがある場合、それを格納し、アイテムを拾える状態にする
            nearbyItem = other.gameObject;
            canPickUp = true;
            itemTextUI.SetActive(true); // テキストを表示
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 衝突から離れたときに呼ばれる
        if (other.CompareTag("Item"))
        {
            // アイテムから離れたので、近くのアイテムをクリアし、アイテムを拾えない状態に戻す
            nearbyItem = null;
            canPickUp = false;
            itemTextUI.SetActive(false); // テキストを非表示
        }
    }

    void PickUpItem()
    {
        // アイテムの取得処理をここに記述
        Debug.Log("アイテムを取得しました: " + nearbyItem.name);

        // アイテムを削除し、関連する変数をリセット
        Destroy(nearbyItem);
        nearbyItem = null;
        canPickUp = false;
        itemTextUI.SetActive(false); // テキストを非表示
    }
}
