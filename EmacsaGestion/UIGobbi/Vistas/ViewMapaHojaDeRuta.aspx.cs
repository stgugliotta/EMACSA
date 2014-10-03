using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EvaWebControls;
using Common.DataContracts;
using Common.Interfaces;
using System.Collections.Generic;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Security;
using Interfaces;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.CoreServices.Caching;
using GoogleMaps;
using Herramientas;
using System.Reflection;


public partial class Vistas_ViewMapaHojaDeRuta : GobbiPage
{
    private String idCliente;
    private String idDeudorInterfaz;
    private String idDeudor;
    private GoogleMapsHelper gmHelper = new GoogleMapsHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__EVENTTARGET"] != null)
        {
            var sourceControl = Request.Params["__EVENTTARGET"].ToString();
            if (sourceControl.Contains("UpdateTimer"))
                return;
        }

        Boolean connectionAvailable = gmHelper.isInternetConnectionAvailable();
        this.GoogleMapForASPNet1.Visible = connectionAvailable;

        this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
            "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxSQ_lADAv5p0VmRdVhcfwwibzpHABRQwumzEz63WA9g7AUiLBfzRk2vkQ";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey =
            "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxTfJTOit7cTdNyZi0-3rP_yLyCMghQQ9WarLGBONAt9MNhg3EfH27IxNA";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxR3EdJHmUzYbv7AOvvHjiyEc3VRdRR5KQlCelmmiBehRf6UcCzMV0V3Zg";
        this.GoogleMapForASPNet1.GoogleMapObject.APIKey = "ABQIAAAAwq_9KEf07Xj6VV1CUM2EqxT3THHYGTp8rSQcCnwaJJWB1HsE_hS_jQHAqsgwsSsBVkGzP9nhQ3Se-Q";
        

        this.GoogleMapForASPNet1.GoogleMapObject.Width = "800px";
        this.GoogleMapForASPNet1.GoogleMapObject.Height = "600px";
        this.GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", 0, 0);


        string sFillGmapsData = Request.QueryString["sfillGmapsData"];
        if (sFillGmapsData!= null && sFillGmapsData.Equals("1")) {
            fillGmapsData();
        }

        fillMap();

    }

    private void fillGmapsData() {
        IDomicilioDeudorService domicilioDeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
        List<DomicilioDeudorDataContracts> domiciliosDeudor = domicilioDeudorService.GetAllDomicilioDeudors();

        foreach (DomicilioDeudorDataContracts domi in domiciliosDeudor) {
            if (domi.GmFormattedAddress == null || domi.GmFormattedAddress.Trim().Length == 0 ) {
                ImportadorInterfaces.fillGmapsData(domi);
                domicilioDeudorService.Update(domi);
            }
        }
    }





    private void fillMap() {
        this.GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
        IHojaService hojaService = ServiceClient<IHojaService>.GetService("HojaService");
        IItemHojaService itemHojaService = ServiceClient<IItemHojaService>.GetService("ItemHojaService");
        IDomicilioDeudorService domicilioDeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");

        List<HojaDataContracts> hojasDC = hojaService.GetAllHojasEntreFechas(DateTime.Today, DateTime.Today);

        if (hojasDC == null || hojasDC.Count == 0)
        {
            return;
        }

        DomicilioDeudorDataContracts domi = null;

        List<ItemHojaDataContracts> itemsHoja = itemHojaService.GetItemsHojaByIdHoja(Int32.Parse(hojasDC[0].IdHoja.ToString()));

        foreach (ItemHojaDataContracts ih in itemsHoja) {
            domi = domicilioDeudorService.GetDomicilioDeudor(ih.IdDeudor);

            if (domi != null) {

                GooglePoint GP = new GooglePoint();
                GP.ID = ih.IdDeudor.ToString();
                GP.Latitude = domi.GmLat;
                GP.Longitude = domi.GmLng;
                GP.InfoHTML = "<b>" + domi.GmFormattedAddress + "- Cobrado: " + (ih.SePago ? "SI" : "NO" ) + "</B>";
                
                this.GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
            }

        }

    }
}
