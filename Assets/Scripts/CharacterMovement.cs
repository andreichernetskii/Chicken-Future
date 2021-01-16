using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Karakter hızı
    [Header("Hareket Ayarları")]
    [Tooltip("Karakterin hızı.")]
    public float characterMoveSpeed = .01f;

    Touch touch;
    private Ray fingerRay;
    private Vector3 fingerPos;
    private Vector3 firstTouchPosition;
    private Vector3 instantTouchPosition;
    private Vector3 touchToCharacterDirection;

    private bool isWalking = false;
    void Start()
    {
        
    }

    void Update()
    {
     
        if(Input.touchCount > 0)
        {
            //Dokunma bilgisi touch isimli değişkende saklanır.
            touch = Input.GetTouch(0);

            //Eğer ekranın sol tarafına dokunulduysa ve yürümekte ise hareket işlemi gerçekleşir.
            if (Camera.main.ScreenToViewportPoint(touch.position).x < .5f || isWalking)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    //İlk parmak pozisyonunu alır.
                    firstTouchPosition = touch.position;

                    //Karakterin yürüdüğü belirtilir.
                    isWalking = true;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    //Anlık parmak pozisyonunu alır.
                    instantTouchPosition = touch.position;

                    //Son ve ilk parmak pozisyonu arası vektör belirler.
                    touchToCharacterDirection = Vector3.Normalize(instantTouchPosition - firstTouchPosition);

                    //Dokunma pozisyonlarına göre hareket işlemi
                    transform.Translate(touchToCharacterDirection.x * characterMoveSpeed * Time.deltaTime, 0, touchToCharacterDirection.y * characterMoveSpeed * Time.deltaTime);

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    //Karakterin durduğu belirtilir.
                    isWalking = false;
                }
            }
        }
        
    }
}
