using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Karakter hızı
    [Header("Hareket Ayarları")]
    [Tooltip("Karakterin hızı.")]
    public float characterMoveSpeed = .01f;

    [HideInInspector]
    public Touch touchOther;
    private Touch touchMovement;
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
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Camera.main.ScreenToViewportPoint(Input.GetTouch(i).position).x < .5f)
                {
                    touchMovement = Input.GetTouch(i);
                }
                else
                {
                    touchOther = Input.GetTouch(i);
                }
            }

            //Eğer ekranın sol tarafına dokunulduysa ve yürümekte ise hareket işlemi gerçekleşir.
            if (Camera.main.ScreenToViewportPoint(touchMovement.position).x < .5f || isWalking)
            {
                if (touchMovement.phase == TouchPhase.Began)
                {
                    //İlk parmak pozisyonunu alır.
                    firstTouchPosition = touchMovement.position;

                    //Karakterin yürüdüğü belirtilir.
                    isWalking = true;

                    //Dönme aktif edilir.
                    GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationY;
                }

                if (touchMovement.phase == TouchPhase.Moved || touchMovement.phase == TouchPhase.Stationary)
                {
                    //Anlık parmak pozisyonunu alır.
                    instantTouchPosition = touchMovement.position;

                    //Son ve ilk parmak pozisyonu arası vektör belirler. (max 1 birim uzunlukta)
                    touchToCharacterDirection = Vector3.ClampMagnitude(instantTouchPosition - firstTouchPosition,1f);

                    //Dokunma pozisyonlarına göre hareket işlemi
                    Move(touchToCharacterDirection);
                }

                if (touchMovement.phase == TouchPhase.Ended)
                {
                    //Karakterin durduğu belirtilir.
                    isWalking = false;
                    //Dönme durdurulur.
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }
            }
        }
        
    }

    /// <summary>
    /// Moving character in vector direction.
    /// </summary>
    /// <param name="direction">Vector3 direction.</param>
    void Move(Vector3 direction)
    {
        //Karakterin hareketi.
        GetComponent<Rigidbody>().velocity = new Vector3(direction.x * characterMoveSpeed, 0, direction.y * characterMoveSpeed);
        //Karakterin dönmesi.
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.y));
    }
}
