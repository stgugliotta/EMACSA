using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
namespace GoogleMaps
{
    
    public class GeocodeResponse
    {
        
        public string status;
        public List<Result> results;
        
    }
    
    public class Result
    {
        public List<String> types;
        public string formatted_address;
        public List<AddressComponent> address_components;
        public Geometry geometry;
    }

    
    public class AddressComponent
    {
        
        public string long_name;
        public string short_name;
        public List<String> types;
        
    }

    public class Geometry
    {
        public Location location;
        public string location_type;
        public ViewPort viewport;
        public Bounds bounds;
    }

    public class Location
    {
        public double lat;
        public double lng;
    }

    public class ViewPort 
    {
        public Location southwest;
        public Location northeast;
    }

    public class Bounds
    {
        public Location southwest;
        public Location northeast;
    }

}
