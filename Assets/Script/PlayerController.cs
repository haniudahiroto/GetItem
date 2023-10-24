using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �L�����N�^�[�̈ړ����x
    public float moveSpeed = 5f;

    // �߂��̃A�C�e�����i�[����ϐ�
    private GameObject nearbyItem;
    private bool canPickUp = false;

    public GameObject itemTextUI; // �e�L�X�g�\���p��UI���A�T�C��

    void Update()
    {
        // �v���C���[�̓��͂��󂯎��
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �ړ��x�N�g�����v�Z���A�L�����N�^�[���ړ�������
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // �A�C�e�����E���������`�F�b�N
        if (canPickUp && Input.GetKeyDown(KeyCode.E) && nearbyItem != null)
        {
            // �A�C�e�����E�����������s
            PickUpItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���̃R���C�_�[�Ƃ̏Փˎ��ɌĂ΂��
        if (other.CompareTag("Item"))
        {
            // �߂��ɃA�C�e��������ꍇ�A������i�[���A�A�C�e�����E�����Ԃɂ���
            nearbyItem = other.gameObject;
            canPickUp = true;
            itemTextUI.SetActive(true); // �e�L�X�g��\��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �Փ˂��痣�ꂽ�Ƃ��ɌĂ΂��
        if (other.CompareTag("Item"))
        {
            // �A�C�e�����痣�ꂽ�̂ŁA�߂��̃A�C�e�����N���A���A�A�C�e�����E���Ȃ���Ԃɖ߂�
            nearbyItem = null;
            canPickUp = false;
            itemTextUI.SetActive(false); // �e�L�X�g���\��
        }
    }

    void PickUpItem()
    {
        // �A�C�e���̎擾�����������ɋL�q
        Debug.Log("�A�C�e�����擾���܂���: " + nearbyItem.name);

        // �A�C�e�����폜���A�֘A����ϐ������Z�b�g
        Destroy(nearbyItem);
        nearbyItem = null;
        canPickUp = false;
        itemTextUI.SetActive(false); // �e�L�X�g���\��
    }
}
