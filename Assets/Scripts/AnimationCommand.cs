using UnityEngine;
public abstract class AnimationCommand
{
    public abstract void Execute(Animator anim, bool state);
}
public class Jump : AnimationCommand
{
    public override void Execute(Animator anim, bool state)
    {
        anim.SetBool("Jump", state);
    }
}
public class PickUp : AnimationCommand
{
    public override void Execute(Animator anim, bool state)
    {
        anim.SetBool("PickUp",state);
    }
}



public class DoNothing : AnimationCommand
{
    public override void Execute(Animator anim, bool state)
    {

    }
}
public abstract class AnimationMovement
{
    public abstract void Execute(Animator anim, float value, float dampTime, float deltaTime);
}

public class BlendMove : AnimationMovement
{
    public override void Execute(Animator anim, float value, float dampTime, float deltaTime)
    {
        anim.SetFloat("Speed", value, dampTime, deltaTime);
    }
}
public class Do_Nothing : AnimationMovement
{
    public override void Execute(Animator anim, float value, float dampTime, float deltaTime)
    {

    }
}
