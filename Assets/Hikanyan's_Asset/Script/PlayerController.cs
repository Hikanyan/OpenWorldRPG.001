using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // プレイヤーの向き
    Vector3 playerPos;
    // 左右キー
    float x;
    // 上下キー
    float z;
    // プレイヤーが倒れないようにする準備
    Rigidbody rd;
    // 移動スピード係数
    float speed = 0.05f;
    // 移動スピード係数（重力ベクトルで移動する場合）
    float velSpeed = 10f;
    // カメラオブジェクト
    GameObject mainCamera;
    // カメラの位置
    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーの重力コンポーネントを取得し、倒れないように回転を制御
        rd = GetComponent<Rigidbody>();
        rd.constraints = RigidbodyConstraints.FreezeRotation;

        // カメラオブジェクトを取得
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        // 左右キーを押した時の値（0～1）
        x = Input.GetAxis("Horizontal");
        // 上下キーを押した時の値（0～1）
        z = Input.GetAxis("Vertical");

        // 方向キー（十字キー）を押した方向
        playerPos = new Vector3(x, 0, z);

        if (playerPos.magnitude > 0.1)
        {
            // 方向キー（十字キー）を押した方向にプレイヤーの向きを変更
            transform.rotation = Quaternion.LookRotation(playerPos);

            // プレイヤーを移動
            transform.Translate(Vector3.forward * speed);

            // 重力ベクトルを変更して移動する場合
            // rd.velocity = new Vector3(x * velSpeed, 0, z * velSpeed);

            // プレイヤーを追随するようにカメラの位置を設定 ※高さと奥行きも調整
            cameraPos = this.gameObject.transform.position;
            cameraPos.y += 5f;
            cameraPos.z += -20f;
            mainCamera.transform.position = cameraPos;
        }
    }
}
