using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask GroundLayers;
    private AnimationCommand jump, pickUp, attacking;
    private AnimationMovement movement;
    private Rigidbody rb;
    private float speed = 3f;
    private float sprint = 6f;
    private InputHandler inputHandler;
    public Vector3 input;
    private float jumpHeight = 2f;
    private float GroundedOffset = 1f;
    private bool Grounded = true;
    private float GroundedRadius = 0.28f;
    private GameObject mainCamera;
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;
    private Animator anim;
    bool isIntroDone = true;
    float targetSpeed;
    public CustomEvent test;
    private GameObject player;
    private void Start()
    {
        jump = new Jump();
        pickUp = new PickUp();
        movement = new BlendMove();
    }
    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        rb = player.GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        anim = player.GetComponent<Animator>();

    }
    float targetRotation;
    private float _rotationVelocity;
    private void Update()
    {
        GroundedCheck();
    }
    void FixedUpdate()
    {
        rb.velocity += input;
        Move();
        Reducer();
        InputInteractions();
    }
    private void Reducer()
    {
        Vector3 reducer = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (input == Vector3.zero)
        {
            reducer = Vector3.MoveTowards(reducer, Vector3.zero, 0.2f);
            reducer.x = Mathf.MoveTowards(reducer.x, 0f, 0.1f);
            reducer.y = Mathf.MoveTowards(reducer.y, 0f, 0.1f);
        }

        if (reducer.magnitude > targetSpeed)
        {
            reducer.Normalize();
            reducer *= targetSpeed;
        }
        rb.velocity = new Vector3(reducer.x, rb.velocity.y, reducer.z);
        input.y = 0f;
    }
    private void Move()
    {
        targetSpeed = inputHandler.sprint ? sprint : speed;
        Vector3 inputDirection = new Vector3(inputHandler.move.x, 0.0f, inputHandler.move.y).normalized;
        if (inputHandler.move != Vector2.zero && isIntroDone)
        {
            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                              mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(player.transform.eulerAngles.y, targetRotation, ref _rotationVelocity,
                RotationSmoothTime);

            //player.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            Vector3 targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
            input = (mainCamera.transform.forward * inputHandler.move.y + mainCamera.transform.right * inputHandler.move.x);

        //    if (inputHandler.sprint)
        //        Run();
        //    else
        //        Walk();
        }
        else
        {
            input = Vector3.zero;
        //    Idle();
        }

        //if (Grounded)
        //{
        //    anim.SetBool("FreeFall", false);
        //    anim.SetBool("Jump", false);

        //}
        //else
        //    anim.SetBool("FreeFall", true);
    }
    public void InputInteractions()
    {
        if (inputHandler.interaction)
        {
           // test.Occurred();            
        }
        if (anim.GetBool("EndLevel"))
        {
            if (inputHandler.interaction)
            {
                Debug.Log("End Lvl");
                GameManager.NextLevel();
            }
        }
    }
        public void OnJump(InputValue value)
    {
        if (value.isPressed && Grounded)
        {
            input += Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight) * Vector3.up;    
            //jump.Execute(anim, true);
        }
    }
    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(player.transform.position.x, player.transform.position.y - GroundedOffset,
            player.transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        anim.SetBool("Grounded", Grounded);
    }

    //private void Idle() TO ENABLE, WHEN ANIMATIONS WILL BE READY
    //{
    //    movement.Execute(anim, 0f, 0.1f, Time.deltaTime);
    //}
    //private void Walk()
    //{
    //    movement.Execute(anim, 0.5f, 0.1f, Time.deltaTime);
    //}
    //private void Run()
    //{
    //    movement.Execute(anim, 1f, 0.1f, Time.deltaTime);
    //}

}
