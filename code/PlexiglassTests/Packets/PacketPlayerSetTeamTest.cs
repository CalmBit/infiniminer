﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plexiglass.Networking;
using Plexiglass.Networking.Handlers;
using Plexiglass.Networking.Packets;

namespace PlexiglassTests.Packets
{
    [TestClass]
    public class PacketPlayerSetTeamTest
    {
        [TestMethod]
        [TestCategory("Packet Registration")]
        public void PacketPlayerSetTeam_RegisteringPacket_Registers()
        {
            var packetRegistry = new PlexiglassPacketRegistry(PacketDirectionality.SERVER_TO_CLIENT);
            packetRegistry.RegisterPacket<PacketPlayerSetTeam, PacketPlayerSetTeamHandler>();
        }

        [TestMethod]
        [TestCategory("Packet Serialization")]
        public void PacketPlayerSetTeam_Serializing_Successful()
        {
            var packet = new PacketPlayerSetTeam
            {
                PlayerId = 0xF005BA11,
                PlayerTeam = 0xEA
            };


            var data = packet.Serialize();
            var comp = new byte[] { 0x11, 0xBA, 0x05, 0xF0, 0xEA };

            Assert.AreEqual(comp.Length, data.Length, "Serialized data was not expected length!");

            for(var i =0;i < data.Length;i++)
            {
                Assert.AreEqual(comp[i], data[i]);
            }
        }

        [TestMethod]
        [TestCategory("Packet Deserialization")]
        public void PacketPlayerSetTeam_Deserialzing_Successful()
        {
            var comp = new byte[] { 0x11, 0xBA, 0x05, 0xF0, 0xEA };

            var packet = new PacketPlayerSetTeam();

            packet.Deserialize(comp);

            Assert.AreEqual(0xF005BA11, packet.PlayerId);
            Assert.AreEqual(0xEA, packet.PlayerTeam);
        }
    }
}
