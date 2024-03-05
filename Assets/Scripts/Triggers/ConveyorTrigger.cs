using Assets.Scripts.Factory.Conveyor;

namespace Assets.Scripts.Triggers
{
    public class ConveyorTrigger : Trigger<Transportable>
    {
        protected override void OnEnter(Transportable triggered)
        {
            Destroy(triggered.gameObject);
        }
    }
}
