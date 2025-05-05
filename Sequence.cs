using LabApi.Features.Wrappers;
using LabApi.Loader.Features.Plugins;
using MapGeneration;
using UnityEngine;
using Unity;
using MEC;
using HCZLock;


namespace HCZLock
{
    internal class HeavyCZLock : Plugin<Configuration.Config>
    {
        Configuration.Config config { get; set; }

        public Plugin plugin;
        public override string Name => "HCZSequence";

        public override string Description => "Lock Down Sequence in HCZ";

        public override string Author => "IIIAuPMa";

        public override System.Version Version { get; }

        public override System.Version RequiredApiVersion { get; }

        public bool HCZIsLocked = false;

        public override void Disable()
        {
            
        }
        public override void Enable()
        {
            
        }

        public void Sequence()
        {

            if (!Cassie.IsSpeaking)

            {

                Map.TurnOnLights(FacilityZone.HeavyContainment);

                foreach (Door door in Door.Get(FacilityZone.HeavyContainment))
                {

                    door.Lock(Interactables.Interobjects.DoorUtils.DoorLockReason.Lockdown2176, false);

                    door.IsLocked = false;

                }

                HCZSystems.HeavyContainmentZone heavyContainmentZone = new HCZSystems.HeavyContainmentZone();

                heavyContainmentZone.HCZAnnouncement();

                heavyContainmentZone.Message();

                heavyContainmentZone.SetLightColor(Color.cyan);

                Timing.CallDelayed(167, () => heavyContainmentZone.HCZDoorsAndCheckpointsLockedDown());

                Timing.CallDelayed(197, () => heavyContainmentZone.TurnOffHCZLights());

                HCZIsLocked = true;

                if (HCZIsLocked == true)
                {

                    //LockDown Sequence Begun Now

                }

            }


        }

    }

}
