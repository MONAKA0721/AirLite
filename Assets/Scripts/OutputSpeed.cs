using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputSpeed : MonoBehaviour
{
  public Text speedText = null;
  private Vector3 latestPos;
  private Vector3 speed;
  private GameObject player;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("Player");
  }

  // Update is called once per frame
  void Update()
  {
    speed = ((player.transform.position - latestPos) / Time.deltaTime);
    latestPos = player.transform.position;
    speedText.text = speed.magnitude.ToString("00") + "km/h";
  }
}
