using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class CarAgent : Agent
{
    [SerializeField] private TrackCheckpoints trackCheckpoints;
    [SerializeField] private Transform spawnTransform;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        trackCheckpoints.OnPlayerCorrectCheckpoint += TrackCheckpoints_OnPlayerCorrectCheckpoint;
        trackCheckpoints.OnPlayerWrongCheckpoint += TrackCheckpoints_OnPlayerWrongCheckpoint;
    }

    private void TrackCheckpoints_OnPlayerCorrectCheckpoint(object sender, TrackCheckpoints.CarCheckpointEventArgs e)
    {
        if (e.carTransform)
        {
            AddReward(+1f);
        }
    }

    private void TrackCheckpoints_OnPlayerWrongCheckpoint(object sender, TrackCheckpoints.CarCheckpointEventArgs e)
    {
        if (e.carTransform)
        {
            AddReward(-1f);
        }
    }

    public override void OnEpisodeBegin()
    {
        transform.position = spawnTransform.position + new Vector3(Random.Range(-5f, +5f), 0f, Random.Range(-5f, +5f));
        transform.forward = spawnTransform.forward;
        trackCheckpoints.ResetCheckpoints();
        player.StopCompletely();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Vector3 checkpointForward = trackCheckpoints.GetNextCheckpoint(transform).transform.forward;
        float directionDot = Vector3.Dot(transform.forward, checkpointForward);
        sensor.AddObservation(directionDot);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        float forwardAmount = 0f;
        float turnAmount = 0f;

        switch (vectorAction[0])
        {
            case 0: forwardAmount = 0f; break;
            case 1: forwardAmount = +1f; break;
            case 2: forwardAmount = -1f; break;
        }

        switch (vectorAction[1])
        {
            case 0: turnAmount = 0f; break;
            case 1: turnAmount = +1f; break;
            case 2: turnAmount = -1f; break;
        }

        player.SetInputs(forwardAmount, turnAmount);
    }

    public override void Heuristic(float[] actionsOut)
    {
        int forwardAction = 0;
        int turnAction = 0;

        if (Input.GetKey(KeyCode.UpArrow))
            forwardAction = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            forwardAction = 2;
        if (Input.GetKey(KeyCode.RightArrow))
            turnAction = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            turnAction = 2;

        actionsOut[0] = forwardAction;
        actionsOut[1] = turnAction;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            AddReward(-0.5f);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            AddReward(-0.1f);
        }
    }
}
