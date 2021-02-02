using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Camera characterCam;
    public Vector3 cameraConstantPosition;

    //Kameranın yumuşatmasının gecikme zamanı.
    public float smooth = 0.2f;
    //kameranın referans noktası.
    private Vector3 _vel = Vector3.zero;
    //Yumuşatılmış pozisyon.
    Vector3 smoothedPosition;

    private void Update()
    {
        //Karakteri takip eden kamera hareketi yumuşatıldı
        smoothedPosition = Vector3.SmoothDamp(characterCam.transform.position, new Vector3(transform.position.x + cameraConstantPosition.x, cameraConstantPosition.y, transform.position.z + cameraConstantPosition.z), ref _vel, smooth);

        //Takip işlemi update şeklinde çalışmakta
        characterCam.transform.position = smoothedPosition;
    }
}
