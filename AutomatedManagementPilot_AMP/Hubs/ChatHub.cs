using AutomatedManagementPilot_AMP.Models;
using AutomatedManagementPilot_AMP.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        //////THIS WORKS AND SENDS MESSAGE AS "SUPERVISOR@GMAIL.COM SAYS ASDOIGUASLDJGALS;DGJ"
        public async System.Threading.Tasks.Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }

        public System.Threading.Tasks.Task SendPrivateMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", message);
        }

 


    }
}