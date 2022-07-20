using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public float MoveSpeed = 5f; // 앞뒤 움직임의 속도
    public float RotateSpeed = 180f; // 좌우 회전 속도


    private PlayerInput _input; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody _rigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator _animator; // 플레이어 캐릭터의 애니메이터

    private static class AnimID
    {
        public static readonly int MOVE = Animator.StringToHash("Move");
    }

    private void Awake()
    {
        // 사용할 컴포넌트들의 참조를 가져오기
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기(초기값 50fps)에 맞춰 실행됨
    // Time.fixedDeltaTime => FixedUpdate에서의 델타타임
    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        move();
        rotate();

        _animator.SetFloat(AnimID.MOVE, _input.MoveDirection);
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void move()
    {
        // 이동거리 = 속력 * 시간
        // 방향 : 캐릭터 기준, 로컬 좌표. 그래서 transform.forward 벡터를 사용한다. Vector3.forward는 월드 좌표.

        // transform.forward * MoveSpeed * Time.fixedDeltaTime * _input.MoveDirection                       // Vector 연산 3번
        Vector3 deltaPosition = MoveSpeed * Time.fixedDeltaTime * _input.MoveDirection * transform.forward; // 최적화 : Vector 연산 1번
        
        _rigidbody.MovePosition(_rigidbody.position + deltaPosition);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void rotate()
    {
        float rotationAmount = RotateSpeed * Time.fixedDeltaTime * _input.RotateDirection;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);

        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);       // Quaternion에서 더 돌아간다는 연산은 곱셈으로 한다. Quaternion 이해했다면 자명.
    }
}