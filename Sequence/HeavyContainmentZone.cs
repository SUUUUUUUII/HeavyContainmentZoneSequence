using System;
using LabApi.Features.Wrappers;
using MapGeneration;
using UnityEngine;
using Unity;
using MEC;
using Configuration;

namespace HCZSystems
{
    internal class HeavyContainmentZone
    {
        Config config = new Config();
      
        public void Message()  //Message to all players
        {
         
                foreach (Player player in Player.List)

                {

                 player.SendBroadcast(config.MessageToAllPlayers, 175, Broadcast.BroadcastFlags.Normal);

                }

        }
        public void SetLightColor() //Set light color default: cyan
        {

            foreach (Room HCZ in Room.Get(FacilityZone.HeavyContainment))

            {

                Map.SetColorOfLights(config.HCZColor, FacilityZone.HeavyContainment);

            }

        }
        public void HCZDoorsAndCheckpointsLockedDown()
        {

            foreach (Door HeavyContainmentZone in Door.Get(FacilityZone.HeavyContainment))
            {
                HeavyContainmentZone.PlayLockBypassDeniedSound();

                HeavyContainmentZone.Lock(Interactables.Interobjects.DoorUtils.DoorLockReason.Lockdown2176, true);

                Timing.CallDelayed(30, () => HeavyContainmentZone.IsLocked = true);

                Timing.CallDelayed(30, () => HeavyContainmentZone.IsOpened = false);


            }

        }
        public void TurnOffHCZLights()
        {
            Map.TurnOffLights(MapGeneration.FacilityZone.HeavyContainment);
        }
        public void HCZAnnouncement()
        {


            if (!Cassie.IsSpeaking)
            {

                Cassie.Message(config.CassieWords,false,false,true,"Последовательность блокировки в Тяжелой Зоне Содержания Задействована \n Зона Тяжелого Содержания будет заблокирована через 3 минуты \n весь персонал должен немедленно покинуть данную зону");

            }

        }



    }


}


