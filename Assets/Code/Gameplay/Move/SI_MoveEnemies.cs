using UnityEngine;

public class SI_MoveEnemies : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    [SerializeField] private float distance = 1f;
    [SerializeField] private float delay = 0.5f;

    private float moveWaitTime = 0f;
    private bool isMoving = false;
    private bool shouldChangeDirection = false;

    private Vector3 moveDirection = Vector3.left;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;

    [Header("Components")]
    private Transform myTransform = null;
    private SI_EnemiesManager enemiesManager = null;
    private SI_IMoveSpeed iMoveSpeed = null;

    private void Awake()
    {
        myTransform = transform;
        enemiesManager = GetComponent<SI_EnemiesManager>();
        iMoveSpeed = GetComponent<SI_IMoveSpeed>();
    }

    private void Update()
    {
        if(moveWaitTime > 0f)
        {
            moveWaitTime -= Time.deltaTime;
        }
    }

    public void Move()
    {
        if(moveWaitTime > 0f)
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

                if(shouldChangeDirection)
                {
                    shouldChangeDirection = false;
                    moveDirection.x *= -1f;
                }
            }
        }
        else
        {
            startPosition = myTransform.position;

            if (enemiesManager.Enemies[0].transform.position.x + distance * moveDirection.x < SI_CameraManager.HorizontalBounds.x)
            {
                endPosition = myTransform.position;
                endPosition.x = SI_CameraManager.HorizontalBounds.x - enemiesManager.Enemies[0].transform.localPosition.x;

                shouldChangeDirection = true;
            }
            else if (enemiesManager.Enemies[enemiesManager.Enemies.Count - 1].transform.position.x + distance * moveDirection.x > SI_CameraManager.HorizontalBounds.y)
            {
                endPosition = myTransform.position;
                endPosition.x = SI_CameraManager.HorizontalBounds.y - enemiesManager.Enemies[enemiesManager.Enemies.Count - 1].transform.localPosition.x;

                shouldChangeDirection = true;
            }
            else
            {
                endPosition = myTransform.position + distance * moveDirection;
            }

            isMoving = true;
        }
    }
}
