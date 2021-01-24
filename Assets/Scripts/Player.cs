using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private static readonly float ROTATION_Y_KEY = 360.0f;	//回転の速度(キーボード)
  private float m_rotationY = 0.0f;		//プレーヤーの回転角度
  public float speed;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    CheckMove();
  }

  void CheckMove()
  {
    {
      //このフレームで動く回転量
      float addRotationY = 0.0f;

      //キー操作による回転
      if (Input.GetKey(KeyCode.LeftArrow))
      {
        addRotationY = -ROTATION_Y_KEY;
      }
      else
      if (Input.GetKey(KeyCode.RightArrow))
      {
        addRotationY = ROTATION_Y_KEY;
      }

      //現在の角度に加算する
      m_rotationY += (addRotationY * Time.deltaTime);   //移動量、回転量には Time.deltaTime を掛けて実行環境(フレーム数の差)による違いが出ないようにする

      //オイラー角で入れる
      transform.rotation = Quaternion.Euler(0, m_rotationY, 0);   //Y軸回転でキャラの向きを横に動かせる
    }

    //移動
    Vector3 addPosition = Vector3.zero;   //移動量(z の値はメカニムにも渡す)
    {

      //移動量をTransformに渡して移動させる
      transform.position += ((transform.rotation * new Vector3(0, 0, speed)) * Time.deltaTime);
      /*
		Vector3にtransform.rotationを掛けると、その方向へ曲げてくれる
		この時、Vector3 は Z+ の方向を正面として考える
	  */
    }
  }
}
