using UnityEngine;
using UnityEngine.Events;

public class SI_MoveEnemies : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    [SerializeField] private float distance = 1f;
    [SerializeField] private float delay = 0.5f;

    private bool isMoving = false;
    private bool shouldMoveDown = false;
    private bool shouldChangeDirection = false;
    private float moveWaitTime = 0f;
    private Vector3 moveDirection = Vector3.left;
    private Vector3 endPosition = Vector3.zero;

    private Vector3 defaultPosition = Vector3.zero;

    [Header("Events")]
    [SerializeField] private UnityEvent<Vector3> onEnemiesMovedDown = null;

    [Header("Components")]
    private Transform myTransform = null;
    private SI_EnemiesManager enemiesManager = null;
    private SI_IMoveSpeed iMoveSpeed = null;
    private SI_IBounds iBounds = null;

    private void Awake()
    {
        myTransform = transform;
        enemiesManager = GetComponent<SI_EnemiesManager>();
        iMoveSpeed = GetComponent<SI_IMoveSpeed>();
        iBounds = GetComponent<SI_IBounds>();

        defaultPosition = myTransform.position;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(moveWaitTime > 0f)
        {
            moveWaitTime -= Time.deltaTime;
        }
    }

    public void Init()
    {
        isMoving = false;
        shouldMoveDown = false;
        shouldChangeDirection = false;
        moveWaitTime = 0f;
        moveDirection = Vector3.left;
        endPosition = defaultPosition;
    }

    public void Move()
    {
        if(enemiesManager.Enemies.Count < 1 || moveWaitTime > 0f)
        {
            return;
        }

        if (isMoving)
        {
            float _moveSpeed = (iMoveSpeed?.MoveSpeed ?? 1f) * Time.deltaTime;
            myTransform.position = Vector3.MoveTowards(myTransform.position, endPosition, _moveSpeed);

            if(Vector3.Distance(myTransform.position, endPosition) < Mathf.Epsilon)
            {
                isMoving = false;
                moveWaitTime = delay;

                if (shouldChangeDirection)
                {
                    shouldChangeDirection = false;

                    moveDirection.x *= -1f;

                    onEnemiesMovedDown?.Invoke(iBounds.Bounds.min);
                }
            }
        }
        else
        {
            if (shouldMoveDown)
            {
                shouldMoveDown = false;

                endPosition = myTransform.position + distance * Vector3.down;

                shouldChangeDirection = true;
            }
            else
            {
                if (iBounds.Bounds.min.x + distance * moveDirection.x < SI_CameraManager.HorizontalBounds.x)
                {

                    endPosition = myTransform.position;
                    endPosition.x += distance * moveDirection.x + (SI_CameraManager.HorizontalBounds.x - (iBounds.Bounds.min.x + distance * moveDirection.x));

                    shouldMoveDown = true;
                }
                else if (iBounds.Bounds.max.x + distance * moveDirection.x > SI_CameraManager.HorizontalBounds.y)
                {
                    endPosition = myTransform.position;
                    endPosition.x += distance * moveDirection.x - ((iBounds.Bounds.max.x + distance * moveDirection.x) - SI_CameraManager.HorizontalBounds.y);

                    shouldMoveDown = true;
                }
                else
                {
                    endPosition = myTransform.position + distance * moveDirection;
                }
            }

            isMoving = true;
        }
    }
}
