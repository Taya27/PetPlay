using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using PetPlayBackend.BusinessLogic.Common;
using PetPlayBackend.BusinessLogic.Services.Interfaces;

namespace PetPlayBackend.BusinessLogic.Services
{
    public class RemoteService : IRemoteService
    {
        private readonly IPAddress _toyIpAddress;
        private readonly int _toyPort;
        private static TcpClient _tcpClient;
        private static NetworkStream _netStream;

        public RemoteService(string ipAddress)
        {
            _toyIpAddress = IPAddress.Parse(ipAddress.Split(':').First());
            _toyPort = int.Parse(ipAddress.Split(":").Last());

            _tcpClient = new TcpClient();
            _tcpClient.Connect(_toyIpAddress, _toyPort);
            _netStream = _tcpClient.GetStream();
        }

        public void TurnOnRing(byte quantity)
        {
            SendData(new[] {quantity});
        }

        public void SetLedState(Led led, LedState state)
        {
            SendData(new[] {(byte)led, (byte)state});
        }
 
        private void SendData(byte[] data)
        {
            try
            {
                if (_netStream.CanWrite)
                {
                    _netStream.Write(data);
                }
            }
            catch(Exception ex) { }
        }
    }
}
