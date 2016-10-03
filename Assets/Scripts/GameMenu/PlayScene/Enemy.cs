using UnityEngine;
using System.Collections;


    public enum EnemyState
    { 
        WANDER,
        PURSUIT,
        ATTACK,
        DISAPPEAR,  
        DIE,
    }

    public class Enemy : StatefulObjectBase<Enemy, EnemyState>
    {
        public enum EnemyType
        {
            UNKNOWN,
            WEAK,
            NEUTRAL,
            DANGEROUS,
            SHY
        }

        public EnemyType type;

        private Transform _player;
        private MeshRenderer _renderer;
        private float _currentlyAlpha;


        public int maxLife = 3;
        private int life;

        public float speed = 5f;
        public float rotationSmooth = 1f;
        public float turretRotationSmooth = 0.8f;
        public float attackInterval = 2f;

        public float happenEventSqrDistance = 1000f;
        public float attackSqrDistance = 900f;
        public float margin = 50f;

        private float changeTargetSqrDistance = 40f;

        public int hitPoints, attack, deffence; 

        public ParticleSystem deathEffect;

        public bool isAngry; // For Neutral enemy

        // Use this for initialization
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            // First, I get to Player position.
            _player = GameObject.FindWithTag("Player").transform;
            _renderer = gameObject.GetComponent<MeshRenderer>();
            deathEffect = GameObject.Find("Explosion").GetComponent<ParticleSystem>();

            life = maxLife;

            // Initialize settiong of state machine.
            _stateList.Add(new StateWander(this));
            _stateList.Add(new StatePursuit(this));
            _stateList.Add(new StateAttack(this));
            _stateList.Add(new StateDisappear(this));
            _stateList.Add(new StateDie(this));


            _stateMachine = new StateMachine<Enemy>();
            //Debug.Log("State Machine: " + _stateMachine.CurrentlyState);

            ChangeState(EnemyState.WANDER);

            #region [ INITIALIZE_ENEMY_PROPAETY ]
            switch (type)
            {
                case EnemyType.UNKNOWN:
                    break;
                case EnemyType.WEAK:
                    hitPoints = 1;
                    attack = 1;
                    deffence = 1;
                    break;
                case EnemyType.NEUTRAL:
                    hitPoints = 10;
                    attack = 10;
                    deffence = 10;
                    speed = 5f;
                    break;
                case EnemyType.DANGEROUS:
                    hitPoints = 5;
                    attack = 10;
                    deffence = 5;
                    break;
                case EnemyType.SHY:
                    //Debug.Log("SHY");
                    hitPoints = 1;
                    attack = 10;
                    deffence = 5;
                    break;
                default:
                    break;
            }
            #endregion
        }

        //// Update is called once per frame
        //void Update()
        //{
        //    //CheckPlayerPosition();

        //    //switch (type)
        //    //{
        //    //    case EnemyType.UNKNOWN:
        //    //        break;
        //    //    case EnemyType.WEAK:
        //    //        EscapeFromPlayer();
        //    //        break;
        //    //    case EnemyType.NEUTRAL:
        //    //        if (isAngry)
        //    //        {
        //    //            ChesePlayer();
        //    //        }
        //    //        break;
        //    //    case EnemyType.DANGEROUS:
        //    //        ChesePlayer();
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}

        //    if (this.transform.position.y <= -500.0f)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}

        //Vector3 GetTarget()
        //{
        //    return new Vector3(Random.Range(0, 300), 0, Random.Range(0, 300));
        //}

        public void ReceiveDamage(int damageNum)
        {
            life--;
            if (life <= 0)
            {
                ChangeState(EnemyState.DIE);
            }
        }


        #region [ STATE_WANDER ]
        private class StateWander : State<Enemy>
        {
            private Vector3 _targetPosition;

            public StateWander(Enemy owner) : base(owner) { }

            public override void Enter()
            {
                // Setting first target.
                _targetPosition = GetRandomPositionOnLevel();

            }

            public override void Execute()
            {


                //Debug.Log(_owner.happenEventSqrDistance);
                // If the distance between Enemy and Player is close, Transition to the tracking state
                float sqrDistanceToPlayer = Vector3.SqrMagnitude(_owner.transform.position - _owner._player.position);

                switch (_owner.type)
                {
                    case EnemyType.DANGEROUS:
                        if (sqrDistanceToPlayer < _owner.happenEventSqrDistance - _owner.margin)
                        {
                            _owner.ChangeState(EnemyState.PURSUIT);
                        }
                        break;

                    case EnemyType.SHY:
                        // if object's alpha less than 1.0f.
                        _owner.fadeIn();
                        if (sqrDistanceToPlayer < _owner.happenEventSqrDistance - _owner.margin)
                        {
                            //Debug.Log("Shy");
                            _owner.ChangeState(EnemyState.DISAPPEAR);
                        }
                        break;

                    default:
                        break;
                }

                // If the distance to targer position is close, Setting next random target point.
                float sqrDistanceToTarget = Vector3.SqrMagnitude(_owner.transform.position - _targetPosition);
                if (sqrDistanceToTarget < _owner.changeTargetSqrDistance)
                {
                    _targetPosition = GetRandomPositionOnLevel();
                }

                // Direct at the target point.
                Quaternion targetRotation = Quaternion.LookRotation(_targetPosition - _owner.transform.position);
                _owner.transform.rotation = Quaternion.Slerp(_owner.transform.rotation, targetRotation, Time.deltaTime * _owner.rotationSmooth);

                // Go forward.
                _owner.transform.Translate(Vector3.forward * _owner.speed * Time.deltaTime);


            }
            public override void Exit() { }

            public Vector3 GetRandomPositionOnLevel()
            {
                float levelSize = 55f;
                return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
            }
        }
        #endregion

        #region [ STATE_PURSUIT ]
        private class StatePursuit : State<Enemy>
        {
            public StatePursuit(Enemy owner) : base(owner) { }

            public override void Enter(){
                Debug.Log("PURSUIT_ENTER");
            }

            public override void Execute()
            {
                Debug.Log("PURSUIT_EXECUTE");

                // If the distance to Player is close, Transition to attack state.
                float sqrDistanceToPlayer = Vector3.SqrMagnitude(_owner.transform.position - _owner._player.position);
                if (sqrDistanceToPlayer < _owner.attackSqrDistance - _owner.margin)
                {
                    _owner.ChangeState(EnemyState.ATTACK);
                }

                // If the distance to player is far, transition to wander state.
                if (sqrDistanceToPlayer > _owner.happenEventSqrDistance + _owner.margin)
                {
                    _owner.ChangeState(EnemyState.WANDER);
                }

                // Direct at the target point.
                Quaternion targetRotation = Quaternion.LookRotation(_owner._player.position - _owner.transform.position);
                _owner.transform.rotation = Quaternion.Slerp(_owner.transform.rotation, targetRotation, Time.deltaTime * _owner.rotationSmooth);

                // Go forward.
                _owner.transform.Translate(Vector3.forward * _owner.speed * Time.deltaTime);
            }

            public override void Exit() { }
        }
        #endregion

        #region [ STATE_ATTACK ]
        private class StateAttack : State<Enemy>
        {
            private float lastAttackTime;

            public StateAttack(Enemy owner) : base(owner) {
            }

            public override void Enter() {
            }

            public override void Execute()
            {
                Debug.Log("ATTACK_EXECUTE");

                // If the distance to Player, transition to pursuit state.
                float sqrDistanceToPlayer = Vector3.SqrMagnitude(_owner.transform.position - _owner._player.position);
                if (sqrDistanceToPlayer > _owner.attackSqrDistance + _owner.margin)
                {
                    _owner.ChangeState(EnemyState.PURSUIT);
                    Debug.Log("Qi");
                }

                // Direction at Player
                //Quaternion targetRotation = Quaternion.LookRotation(_owner._player.position - _owner.turret.position);
                //_owner.transform.rotation = Quaternion.Slerp(_owner.transform.rotation, targetRotation, Time.deltaTime * _owner.turretRotationSmooth);

            }

            public override void Exit() {

            }
        }
        #endregion


        #region [ STATE_DISAPPEAR ]

        private class StateDisappear : State<Enemy>
        {

            public StateDisappear(Enemy owner) : base(owner) { }

            public override void Enter()
            {
                Debug.Log("Disappear" + _owner.gameObject.GetComponent<MeshRenderer>().material.color);
            }
            public override void Execute()
            {
                _owner.fadeOut();

                Debug.Log(_owner._renderer.material.color.a);

                // If the distance to Player is close, Transition to attack state.
                float sqrDistanceToPlayer = Vector3.SqrMagnitude(_owner.transform.position - _owner._player.position);
                // If the distance to player is far, transition to wander state.
                if (sqrDistanceToPlayer > _owner.happenEventSqrDistance + _owner.margin)
                {
                    _owner.ChangeState(EnemyState.WANDER);
                }
            }
            public override void Exit()
            {
            }

        }

        #endregion

        #region [ STATE_DIE ]
        private class StateDie : State<Enemy>
        {

            public StateDie(Enemy owner) : base(owner) { }

            public override void Enter()
            {
                // Applying random force.
                Vector3 force = Vector3.up * 1000f + Random.insideUnitSphere * 300f;
                _owner.GetComponent<Rigidbody>().AddForce(force);

                // Applying random rotational force.
                Vector3 torque = new Vector3(Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
                _owner.GetComponent<Rigidbody>().AddTorque(torque);

               
                // Destroy myself 1 sec later.
                Destroy(_owner.gameObject, 1.0f);
                _owner.deathEffect.transform.position = _owner.gameObject.transform.position;
                _owner.deathEffect.startDelay = 2f;
                _owner.deathEffect.Play();

            }

            public override void Execute() { }

            public override void Exit() {
               
            }
        }
        #endregion

        public void fadeOut()
        {
            if (_currentlyAlpha > 0f)
                _currentlyAlpha -= 0.1f;
            else
                _renderer.enabled = false;

            _renderer.material.color = new Color(0, 0.588f, 0.077f, _currentlyAlpha);
        }
        public void fadeIn()
        {
            if (_currentlyAlpha < 1f)
                _currentlyAlpha += 0.1f;
            else
                _renderer.enabled = true;

            _renderer.material.color = new Color(0, 0.588f, 0.077f, _currentlyAlpha);
        }
    }