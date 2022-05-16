using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SI_MoveEnemies : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    [SerializeField] private float delayToMoveOnStart = 1f;
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private float delayBetweenStep = 0.5f;

    private bool canMove = false;
    private bool isMoving = false;
    private bool shouldMoveDown = false;
    private bool shouldChangeDirection = false;
    private float moveWaitTime = 0f;
    private Vector3 moveDirection = Vector3.left;
    private Vector3 endPosition = Vector3.zero;
    private WaitForSeconds delayToMoveOnStartWaiter = null;

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

        delayToMoveOnStartWaiter = new WaitForSeconds(delayToMoveOnStart);

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
        canMove = false;
        isMoving = false;
        shouldMoveDown = false;
        shouldChangeDirection = false;
        moveWaitTime = 0f;
        moveDirection = Vector3.left;
        endPosition = defaultPosition;

        StartCoroutine(init());
    }

    public void Move()
    {
        if(canMove == false || enemiesManager.Enemies.Count < 1 || moveWaitTime > 0f)
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
                moveWaitTime = delayBetweenStep;

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

                endPosition = myTransform.position + distanceToMove * Vector3.down;

                shouldChangeDirection = true;
            }
            else
            {
                if (iBounds.Bounds.min.x + distanceToMove * moveDirection.x < SI_CameraManager.HorizontalBounds.x)
                {

                    endPosition = myTransform.position;
                    endPosition.x += distanceToMove * moveDirection.x + (SI_CameraManager.HorizontalBounds.x - (iBounds.Bounds.min.x + distanceToMove * moveDirection.x));

                    shouldMoveDown = true;
                }
                else if (iBounds.Bounds.max.x + distanceToMove * moveDirection.x > SI_CameraManager.HorizontalBounds.y)
                {
                    endPosition = myTransform.position;
                    endPosition.x += distanceToMove * moveDirection.x - ((iBounds.Bounds.max.x + distanceToMove * moveDirection.x) - SI_CameraManager.HorizontalBounds.y);

                    shouldMoveDown = true;
                }
                else
                {
                    endPosition = myTransform.position + distanceToMove * moveDirection;
                }
            }

            isMoving = true;
        }
    }

    private IEnumerator init()
    {
        yield return delayToMoveOnStartWaiter;

        canMove = true;
    }
}
