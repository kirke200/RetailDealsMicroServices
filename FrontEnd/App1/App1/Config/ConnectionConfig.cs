using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Config
{
    public static class ConnectionConfig
    {
        static bool isRelease = false;

        static string ApiBaseAdressDebug = "http://192.168.0.150:5000";
        static string ApiBaseAdressRelease = "http://192.168.0.150:5000/api/RetailGroups?name=Kvickly";



        public static string GetAPIBaseAdress()
        {
            if (isRelease)
                return ApiBaseAdressRelease;
            else
                return ApiBaseAdressDebug;
        }


    }
}
