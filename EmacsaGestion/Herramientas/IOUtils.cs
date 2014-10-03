using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Common.DataContracts;
using Common.Interfaces;
using System.Collections.Generic;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;




namespace Herramientas
{
    public class IOUtils
    {

        public static String createTemporalFile(byte[] bytes, String fileName) {

            IConfigurationService configurationServices = ServiceClient<IConfigurationService>.GetService("ConfigurationService");


            String tempDirectory = configurationServices.Load(1).Valor;


            String timeStamp = DateTime.Now.ToFileTime().ToString();

            String tempFileName = tempDirectory + "\\" + timeStamp + "_" + fileName;

            FileStream tempFile = new FileStream (tempFileName, FileMode.CreateNew );
            tempFile.Write(bytes,0, bytes.Length );

            tempFile.Close();


            return tempFile.Name ;
        }
    }
}
