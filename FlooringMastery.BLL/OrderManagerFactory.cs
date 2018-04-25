using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public class OrderManagerFactory
    {

        public static OrderManager Create()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            string mode = ConfigurationSettings.AppSettings["Mode"].ToString();
#pragma warning restore CS0618 // Type or member is obsolete

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository());
                case "Prod":
                    return new OrderManager(new FileOrderRepository(FilePathSetting.FilePath));
                default:
                    throw new Exception("Mode Value in app config is not valid");
            }
        }

       
        
    }
}
