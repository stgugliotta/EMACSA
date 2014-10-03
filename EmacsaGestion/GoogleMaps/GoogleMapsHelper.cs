using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;


namespace GoogleMaps
{
    public class GoogleMapsHelper
    {

        public string getJSONResponse(string searchCriteria) {
            string SEARCH_URL = "http://maps.google.com/maps/api/geocode/json?sensor=false&address=";
            WebClient client = new WebClient();
            return System.Text.Encoding.ASCII.GetString(client.DownloadData(SEARCH_URL + searchCriteria));
        }

        public GeocodeResponse getGeocodeResponse(string searchCriteria)
        {
            GeocodeResponse gmResponse = null;
            //string path = "C:\\temp\\json_GoogleMaps_otroFormato2.json";

            try {
                //StreamReader streamReader = new StreamReader(path);
                string googleSearchText = getJSONResponse(searchCriteria); //streamReader.ReadToEnd();

                JObject googleSearch = JObject.Parse(googleSearchText);

                GeocodeResponse geocodeResponse = JsonConvert.DeserializeObject<GeocodeResponse>(googleSearch.ToString());

                return geocodeResponse;

            }
            catch (Exception e) {
                //Console.Write(e);
            }

            
            return null;
        }


        public Boolean isInternetConnectionAvailable() {

            HttpWebRequest req;
            HttpWebResponse resp;
            try
            {
                req = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                resp = (HttpWebResponse)req.GetResponse();

                if (resp.StatusCode.ToString().Equals("OK"))
                {
                    //Console.WriteLine("its connected.");
                    return true;
                }
                else
                {
                    //Console.WriteLine("its not connected.");
                    return false;
                }
            }
            catch (Exception exc)
            {
                //Console.WriteLine("its not connected.");
                return false;
            }
        }



    }
}
