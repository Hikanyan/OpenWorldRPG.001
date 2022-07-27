using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �v���C���[�̌���
    Vector3 playerPos;
    // ���E�L�[
    float x;
    // �㉺�L�[
    float z;
    // �v���C���[���|��Ȃ��悤�ɂ��鏀��
    Rigidbody rd;
    // �ړ��X�s�[�h�W��
    float speed = 0.05f;
    // �ړ��X�s�[�h�W���i�d�̓x�N�g���ňړ�����ꍇ�j
    float velSpeed = 10f;
    // �J�����I�u�W�F�N�g
    GameObject mainCamera;
    // �J�����̈ʒu
    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[�̏d�̓R���|�[�l���g���擾���A�|��Ȃ��悤�ɉ�]�𐧌�
        rd = GetComponent<Rigidbody>();
        rd.constraints = RigidbodyConstraints.FreezeRotation;

        // �J�����I�u�W�F�N�g���擾
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        // ���E�L�[�����������̒l�i0�`1�j
        x = Input.GetAxis("Horizontal");
        // �㉺�L�[�����������̒l�i0�`1�j
        z = Input.GetAxis("Vertical");

        // �����L�[�i�\���L�[�j������������
        playerPos = new Vector3(x, 0, z);

        if (playerPos.magnitude > 0.1)
        {
            // �����L�[�i�\���L�[�j�������������Ƀv���C���[�̌�����ύX
            transform.rotation = Quaternion.LookRotation(playerPos);

            // �v���C���[���ړ�
            transform.Translate(Vector3.forward * speed);

            // �d�̓x�N�g����ύX���Ĉړ�����ꍇ
            // rd.velocity = new Vector3(x * velSpeed, 0, z * velSpeed);

            // �v���C���[��ǐ�����悤�ɃJ�����̈ʒu��ݒ� �������Ɖ��s��������
            cameraPos = this.gameObject.transform.position;
            cameraPos.y += 5f;
            cameraPos.z += -20f;
            mainCamera.transform.position = cameraPos;
        }
    }
}
