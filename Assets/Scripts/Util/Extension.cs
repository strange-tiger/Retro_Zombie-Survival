using UnityEngine;

public static class Extension
{
    // PlayerShooter.cs에서 사용한 SetIKPosition  등 관련 메소드를 묶은 확장 메소드를 만들어 보자.
    // SetIKPositionAndWeight
    public static void SetIKPositionAndWeight(this Animator animator, AvatarIKGoal goal, Vector3 goalPosition, float weight = 1f)
    {
        animator.SetIKPositionWeight(goal, weight);
        animator.SetIKPosition(goal, goalPosition);
    }

    // SetIKRotationAndWeight
    public static void SetIKRotationAndWeight(this Animator animator, AvatarIKGoal goal, Quaternion goalRotation, float weight = 1f)
    {
        animator.SetIKRotationWeight(goal, weight);
        animator.SetIKRotation(goal, goalRotation);
    }

    // SetIKTransformAndWeight
    public static void SetIKTransformAndWeight(this Animator animator, AvatarIKGoal goal, Transform goalTransform, float weight = 1f)
    {
        animator.SetIKPositionAndWeight(goal, goalTransform.position, weight);
        animator.SetIKRotationAndWeight(goal, goalTransform.rotation, weight);
    }
}