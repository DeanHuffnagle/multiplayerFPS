using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
   [SerializeField]
   private float speed = 5f;
   [SerializeField]
   private float sensitivity = 3f;

   private PlayerMotor motor;

  void Start() {
      motor = GetComponent<PlayerMotor>();
   }


    void Update() {
      float _xMov = Input.GetAxisRaw("Horizontal");
      float _zMov = Input.GetAxisRaw("Vertical");

      Vector3 _MoveHorizontal = transform.right * _xMov;
      Vector3 _MoveVertical = transform.forward * _zMov;

      Vector3 _Velocity = (_MoveHorizontal + _MoveVertical).normalized * speed;


      motor.Move(_Velocity);

      float _yRot = Input.GetAxisRaw("Mouse X");

      Vector3 _Rotation = new Vector3(0f, _yRot, 0f) * sensitivity;

      motor.Rotate(_Rotation);



      float _xRot = Input.GetAxisRaw("Mouse Y");

      Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * sensitivity;

      motor.RotateCamera(_cameraRotation);

   }
}
