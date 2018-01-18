﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Resources.Utils
{
    public class GeneralMessages
    {
        public static string GetUsersSuccess
        {
            get { return "GetUsers : Success"; }
        }

        public static string GetUsersError
        {
            get { return "GetUsers : Error"; }
        }

        public static string SaveUserSuccess
        {
            get { return "SaveUser : Success"; }
        }

        public static string SaveUserError
        {
            get { return "SaveUser : Error"; }
        }

        public static string GetConsumersSuccess
        {
            get { return "GetConsumers : Success"; }
        }

        public static string GetConsumersError
        {
            get { return "GetConsumers : Error"; }
        }

        public static string SaveConsumerError
        {
            get { return "SaveConsumer : Error"; }
        }

        public static string SavePhoneSuccess
        {
            get { return "SavePhone : Success"; }
        }

        public static string SavePhoneError
        {
            get { return "SavePhone : Error"; }
        }

        public static string GetGeneratedTokenSuccess
        {
            get { return "GetGeneratedToken : Token Generated with Success"; }
        }

        public static string GetGeneratedTokenError
        {
            get { return "GetGeneratedToken : Error"; }
        }
    }
}
