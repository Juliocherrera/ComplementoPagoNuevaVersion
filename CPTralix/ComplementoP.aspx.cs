using CPTralix.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CPTralix
{
    public partial class ComplementoP : System.Web.UI.Page
    {
        public FacCpController facLabControler = new FacCpController();
        public List<string> f02 = new List<string>();
        public string fDesde, fHasta, concepto, tipoCobro, tipocomprobante, lugarexpedicion, metodopago33, formadepago, usocfdi, confirmacion, paisresidencia, numtributacion
        , mailenvio, numidentificacion, claveunidad, tipofactoriva, tipofactorret, coditrans, tipofactor, tasatras, codirete, tasarete, relacion, montosoloiva, montoivarete
        , ivadeiva, ivaderet, retderet, conceptoretencion, consecutivoconcepto, claveproductoservicio, valorunitario, importe, descuento, cantidadletra, uuidrel
        , identificador, version, fechapago, monedacpag, tipodecambiocpag, monto, numerooperacion, rfcemisorcuenta, nombrebanco, numerocuentaord, rfcemisorcuentaben, numcuentaben
        , tipocadenapago, certpago, cadenadelpago, sellodelpago, identpag, identdocpago, seriecpag, foliocpag, monedacpagdoc, tipocambiocpag, metododepago, numerodeparcialidad,f03,f04, IdentificadorDelDocumentoPagado, identificaciondpago, serieinvoice, folioscpag, monedascpadgoc, nparcialidades,interiorsaldoanterior,ipagadoisaldoinsoluto, ipagado, isaldoinsoluto,k1,k3,f05,iva,retencion
        , importeSaldoAnterior, importepago, importesaldoinsoluto, total, subt, ivat, rett, cond, tipoc, seriee, folioe, sfolio, idcomprobante, fecha, tmoneda, Tdoc, IdCliente, RFC, Cliente, Pais, Calle, NoExt, NoInt, Colonia, Localidad, Referencia, Municipio, Estado, CP, FechaPago, cantidad, descripcion, RFCbancoEmisor, BancoEmisor, CuentaPago,Total, identificadorDelPago, formadepagocpag,mmonto,if05,if06, iipagado, totaliva, totalisr, foliop, receptorp, MetdodoPagop, uidp;

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                iniciaDatos();
            }
            catch (Exception EX)
            {
                string error = EX.Message;
            }



        }

        public void iniciaDatos()
        {
            //string folio = "40524";
            //string folio = "40658";
            //string folio = "40654";
            //string folio = "40647";
            //string folio = "40646";
            //string folio = "40645";
            //string folio = "40643";
            string folio = "40525";
            DataTable td = facLabControler.detalleFacturas(folio);
            string datestring = DateTime.Now.ToString("yyyyMMddHHmmss");

            foreach (DataRow row in td.Rows)
            {
                //Asignar valores 01
                idcomprobante = row["IdComprobante"].ToString();
                seriee = row["Serie"].ToString();
                folioe = row["Folio"].ToString();
                DateTime dt = DateTime.Parse(row["FechaHoraEmision"].ToString());
                fecha = dt.ToString("yyyy'/'MM'/'dd HH:mm:ss");
                subt = row["Subtotal"].ToString();
                //ivat = row["TotalImpuestosTrasladados"].ToString();
                //rett = row["TotalImpuestosRetenidos"].ToString();
                total = row["Total"].ToString();
                //cantidadletra = row["Totalconletra"].ToString();
                formadepago = row["FormaDePago"].ToString();
                //cond = row["CondicionesdePago"].ToString();
                metodopago33 = row["MetodoPago"].ToString();
                tmoneda = row["Moneda"].ToString();
                //tipoc = row["Tipodecambio"].ToString();
                tipocomprobante = row["TipodeComprobante"].ToString();
                lugarexpedicion = row["LugardeExpedición"].ToString();
                usocfdi = row["UsoCFDI"].ToString();
                Tdoc = "FAC";
                //confirmacion = row["Confirmación"].ToString();
                //string f01 = "|01|" + idcomprobante + "|";

                //02-------------------------------------------------------------------------------------------------------------------------

                IdCliente = row["IdReceptor"].ToString();

                RFC = row["RFC"].ToString();
                Cliente = row["Nombre"].ToString();
                Pais = row["Pais"].ToString();
                Calle = row["Calle"].ToString();
                NoExt = row["NumeroExterior"].ToString();
                NoInt = row["NumeroInterior"].ToString();
                Colonia = row["Colonia"].ToString();
                Localidad = row["Localidad"].ToString();
                Referencia = row["Referencia"].ToString();
                Municipio = row["MunicipioDelegacion"].ToString();
                Estado = row["Estado"].ToString();
                CP = row["CódigoPostal"].ToString();
                FechaPago = row["Fechapago"].ToString();
                paisresidencia = row["PaísResidenciaFiscal"].ToString();
                numtributacion = row["NúmeroDeRegistroIdTributacion"].ToString();
                mailenvio = row["CorreoEnvio"].ToString();

                //04-------------------------------------------------------------------------------------------------------------------------
                consecutivoconcepto = row["ConsecutivoConcepto"].ToString();
                claveproductoservicio = row["ClaveProductooServicio"].ToString();
                cantidad = row["Cantidad"].ToString();
                claveunidad = row["ClaveUnidad"].ToString();
                descripcion = row["Descripcion"].ToString();
                valorunitario = row["ValorUnitario"].ToString();
                importe = row["Importe"].ToString();

                //CPAG-------------------------------------------------------------------------------------------------------------------------


                DateTime dtdtt = DateTime.Parse(row["Fechapago"].ToString());
                fechapago = dtdtt.ToString("yyyy'-'MM'-'dd'T'HH:mm:ss");
                //fechapago =
                identificador = row["Identificador"].ToString();
                version = row["version"].ToString();
                //txtFormaPago.Text = row["Formadepagocpag"].ToString();
                monedacpag = row["Monedacpag"].ToString();
                tipodecambiocpag = row["TipoDeCambiocpag"].ToString();
                monto = row["Monto"].ToString();
                numerooperacion = row["NumeroOperacion"].ToString();
                RFCbancoEmisor = row["RFCEmisorCuentaBeneficiario"].ToString();
                BancoEmisor = row["NombreDelBanco"].ToString();
                CuentaPago = row["NumeroCuentaOrdenante"].ToString();
                rfcemisorcuentaben = row["RFCEmisorCuentaBeneficario"].ToString();
                numcuentaben = row["NumerCuentaBeneficiario"].ToString();
                tipocadenapago = row["TipoCadenaPago"].ToString();
                certpago = row["CertificadoPago"].ToString();
                cadenadelpago = row["CadenaDePago"].ToString();
                sellodelpago = row["SelloDePago"].ToString();
                identificadorDelPago = row["IdentificadorDelPago"].ToString();
                formadepagocpag = row["Formadepagocpag"].ToString();
                monedacpag = row["Monedacpag"].ToString();



                //CPAGDOC-----------------------------------------------------------------------------------------------------------------------
                DataTable detalleIdent = facLabControler.getDatosCPAGDOC(identificadorDelPago);
                //string uid = "";
                decimal importePagos = 0;
                double ivaa = 0.16;
                double isrr = 0.04;
                decimal totalIva = 0;
                decimal totalIsr = 0;
                //int contadorPUE = 0;
                //int contadorPPD = 0;
                string MetdodoPago = row["MedotoDePago"].ToString();
                //string uidp = "";


                foreach (DataRow rowIdent in detalleIdent.Rows)
                {
                    ////aqui va el codigo en produccion -------------------------------------
                        
                    //    //Primer liena copiada la variable original es folio la cambie pod foliop
                    //    foliop = Regex.Replace(rowIdent["Foliocpag"].ToString().Replace("TDR", "").Trim(), @"[A-Z]", "");
                    ////segunda linea copiada - receptor lo cambie por receptorp
                    //string receptorp = IdCliente.ToString().Trim();
                    ////tercer codigo copiada
                    //string serieinvoice = "";
                    //if (receptorp.Equals("LIVERPOL") || receptorp.Equals("LIVERDED") || receptorp.Equals("ALMLIVER") || receptorp.Equals("LIVERTIJ") || receptorp.Equals("SFERALIV") || receptorp.Equals("GLOBALIV") || receptorp.Equals("SETRALIV") || receptorp.Equals("FACTUMLV"))
                    //{
                    //    serieinvoice = "TDRL";
                    //}
                    //else
                    //{
                    //    serieinvoice = rowIdent["Seriecpag"].ToString();
                    //}

                    //// cuarta parte del codigo copiado

                    //foliop = Regex.Replace(rowIdent["Foliocpag"].ToString().Replace("TDR", "").Trim(), @"[A-Z]", "");
                    //if (foliop.Length == 7 && foliop.StartsWith("99"))
                    //{
                    //    foliop = folio.Substring(foliop.Length - 6, 6);
                    //}
                    //else if (foliop.Length == 8)
                    //{
                    //    foliop = foliop.Substring(foliop.Length - 7, 7);
                    //}
                    //foliop = foliop.Replace("-", "");

                    //// siguiente codigo copiado, la variable MetdodoPago lo cambie por MetdodoPagop

                    //var MetdodoPagop = "";

                    //DataTable datosMaster = facLabControler.getDatosMaster(folio);
                    //if (datosMaster.Rows.Count > 0)
                    //{
                    //    foreach (DataRow rowMaster in datosMaster.Rows)
                    //    {
                    //        string invoiceMaster = Regex.Replace(rowMaster[0].ToString(), @"[A-Z]", "");
                    //        folio = invoiceMaster;
                    //        var request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + invoiceMaster + "&serie=" + serieinvoice);
                    //        var response = (HttpWebResponse)request.GetResponse();
                    //        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    //        MetdodoPago = "PPD";
                    //        string[] separadas = responseString.Split(',');
                    //        foreach (string dato in separadas)
                    //        {
                    //            if (dato.Contains("uuid"))
                    //            {
                    //                uidp = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "").Replace(":", "");
                    //            }
                    //            if (serieinvoice != "TDRL")
                    //            {
                    //                if (dato.Contains("xmlDownload"))
                    //                {

                    //                    string xml = dato.Replace(dato.Substring(0, 15), "").Replace("\"", "");
                    //                    XmlDocument xDoc = new XmlDocument();
                    //                    xDoc.Load("https://canal1.xsa.com.mx:9050" + xml);
                    //                    var xmlTexto = xDoc.InnerXml.ToString();
                    //                    if (xmlTexto.Contains("MetodoPago=\"PPD\""))
                    //                    {
                    //                        MetdodoPago = "PPD";
                    //                        contadorPPD++;
                    //                        //PopupMsg.Message1 = "La factura es PPD!!";
                    //                        //PopupMsg.ShowPopUp(0);
                    //                    }
                    //                    else if (xmlTexto.Contains("MetodoPago=\"PUE\""))
                    //                    {
                    //                        MetdodoPago = "PUE";
                    //                        contadorPUE++;
                    //                        //PopupMsg.Message1 = "La factura es PUE!!";
                    //                        //PopupMsg.ShowPopUp(0);
                    //                    }
                    //                }

                    //            }
                    //        }

                    //    }

                    //}
                    //else
                    //{

                    //    var request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + folio + "&serie=" + serieinvoice);
                    //    var response = (HttpWebResponse)request.GetResponse();
                    //    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    //    MetdodoPago = "PPD";
                    //    string[] separadas = responseString.Split(',');


                    //    foreach (string dato in separadas)
                    //    {
                    //        if (dato.Contains("uuid"))
                    //        {
                    //            uidp = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "").Replace(":", "");
                    //        }
                    //        if (serieinvoice != "TDRL")
                    //        {
                    //            if (dato.Contains("xmlDownload"))
                    //            {

                    //                string xml = dato.Replace(dato.Substring(0, 15), "").Replace("\"", "");
                    //                XmlDocument xDoc = new XmlDocument();
                    //                xDoc.Load("https://canal1.xsa.com.mx:9050" + xml);
                    //                var xmlTexto = xDoc.InnerXml.ToString();
                    //                if (xmlTexto.Contains("MetodoPago=\"PPD\""))
                    //                {
                    //                    MetdodoPago = "PPD";
                    //                    contadorPPD++;
                    //                    //PopupMsg.Message1 = "La factura es PPD!!";
                    //                    //PopupMsg.ShowPopUp(0);
                    //                }
                    //                else if (xmlTexto.Contains("MetodoPago=\"PUE\""))
                    //                {
                    //                    MetdodoPago = "PUE";
                    //                    contadorPUE++;
                    //                    //PopupMsg.Message1 = "La factura es PUE!!";
                    //                    //PopupMsg.ShowPopUp(0);
                    //                }
                    //            }
                    //        }
                    //    }
                    //    if (uidp == "" && serieinvoice == "TDRA")
                    //    {
                    //        request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + folio + "&serie=" + "SAEM");
                    //        response = (HttpWebResponse)request.GetResponse();
                    //        responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    //        separadas = responseString.Split(',');


                    //        foreach (string dato in separadas)
                    //        {
                    //            if (dato.Contains("uuid"))
                    //            {
                    //                uidp = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "").Replace(":", "");
                    //            }
                    //            if (dato.Contains("xmlDownload"))
                    //            {

                    //                string xml = dato.Replace(dato.Substring(0, 15), "").Replace("\"", "");
                    //                XmlDocument xDoc = new XmlDocument();
                    //                xDoc.Load("https://canal1.xsa.com.mx:9050" + xml);
                    //                var xmlTexto = xDoc.InnerXml.ToString();
                    //                if (xmlTexto.Contains("MetodoPago=\"PPD\""))
                    //                {
                    //                    MetdodoPago = "PPD";
                    //                    contadorPPD++;
                    //                    //PopupMsg.Message1 = "La factura es PPD!!";
                    //                    //PopupMsg.ShowPopUp(0);
                    //                }
                    //                else if (xmlTexto.Contains("MetodoPago=\"PUE\""))
                    //                {
                    //                    MetdodoPago = "PUE";
                    //                    contadorPUE++;
                    //                    //PopupMsg.Message1 = "La factura es PUE!!";
                    //                    //PopupMsg.ShowPopUp(0);
                    //                }

                    //            }
                    //        }
                    //    }

                    //}


                    //aqui termina -----------------------------------------------------------------------------------------------------

                    if (MetdodoPago == "PPD")
                    {
                        importepago = rowIdent["ImportePagado"].ToString();
                        try
                        {
                            importePagos = importePagos + Convert.ToDecimal(importepago);
                            Total = importePagos.ToString();
                        }
                        catch (Exception ex)
                        {
                            string errors = ex.Message;
                        }
                        identificaciondpago = rowIdent["IdentificadorDelPago"].ToString();
                        IdentificadorDelDocumentoPagado = rowIdent["IdentificadorDelDocumentoPagado"].ToString();
                        serieinvoice = rowIdent["Seriecpag"].ToString();
                        folioscpag = rowIdent["Foliocpag"].ToString();
                        monedascpadgoc = rowIdent["Monedacpagdoc"].ToString();
                        nparcialidades = rowIdent["NumeroDeParcialidad"].ToString();
                        interiorsaldoanterior = rowIdent["ImporteSaldoAnterior"].ToString();
                        ipagado = rowIdent["ImportePagado"].ToString();
                        isaldoinsoluto = rowIdent["ImporteSaldoInsoluto"].ToString();

                        //aqui comienza el IF
                        //if (monedacpagdoc.Trim() == "USD")
                        //{
                        //    f04 += "CPAG20DOC"
                        //     + "|" + identificaciondpago
                        //     + "|" + IdentificadorDelDocumentoPagado
                        //     + "|"
                        //     + "|"
                        //     + "|" + monedascpadgoc
                        //     + "|"
                        //     + "|" + nparcialidades
                        //     + "|" + interiorsaldoanterior
                        //     + "|" + ipagado
                        //     + "|" + isaldoinsoluto
                        //     + "|" + "02"
                        //     + "| \r\n"
                        //     + if05
                        //     + if06;

                        //    cpagdoc = cpagdoc + ("CPAGDOC"                           //1-Tipo De Registro
                        //      + "|" + identpag                                       //2-IdentificadorDelPago
                        //                                                             //+ "|" + rowIdent["IdentificadorDelDocumentoPagado"].ToString()                            //3-IdentificadorDelDocumentoPagado                                              
                        //      + "|" + uid                                            //3-IdentificadorDelDocumentoPagado                                              
                        //      + "|" + serieinvoice                                   //4-Seriecpag
                        //      + "|" + foliocpag                                      //5-Foliocpag
                        //      + "|" + monedacpagdoc                                  //6-Monedacpag
                        //      + "|" + ""                                             //7-TipoCambiocpagdpc
                        //      + "|" + txtMetodoPago.Text                             //8-MetodoDePago
                        //      + "|" + numerodeparcialidad                            //9-NumeroDeParcialidad
                        //      + "|" + importepago                                    //10-ImporteSaldoAnterior
                        //      + "|" + importepago                                    //11-ImportePagado                                                  
                        //      + "|" + "0"                                            //12 ImporteSaldoInsoluto
                        //      + "| \r\n");
                        //}


                        //Aqui termina el IF

                        // Esto va en le ELSE
                        DataTable detalleIdentt = facLabControler.getDatosCPAGDOCTRL(identificaciondpago, folioscpag);

                        if (detalleIdentt.Rows.Count > 0)
                        {
                            foreach (DataRow rowIdentt in detalleIdentt.Rows)
                            {
                                k1 = rowIdentt["K1"].ToString();
                                k3 = rowIdentt["K3"].ToString();
                                iva = rowIdentt["IVA"].ToString();
                                retencion = rowIdentt["RETENCION"].ToString();
                                iipagado = rowIdentt["ActualApplyToAmount"].ToString();
                                totalIva = (decimal)(ivaa * Convert.ToDouble(iipagado));
                                totaliva = totalIva.ToString("F");
                                totalIsr = (decimal)(isrr * Convert.ToDouble(iipagado));
                                totalisr = totalIsr.ToString("F");

                                if (iva != "")
                                {
                                    if05 = "CPAG20DOCIMPRET"
                                    + "|" + k1.Trim()
                                    + "|" + k3.Trim()
                                    + "|" + IdentificadorDelDocumentoPagado.Trim()
                                    + "|" + "002"
                                    + "|" + "Tasa"
                                    + "|" + "0.160000"
                                    + "|" + totaliva
                                    //+ "|" + iva.Trim()
                                    + "|" + ipagado.Trim()
                                    + "| \r\n";
                                }
                                if (retencion !="")
                                {
                                    if06 = "CPAG20DOCIMPTRA"
                                    + "|" + k1.Trim()
                                    + "|" + k3.Trim()
                                    + "|" + IdentificadorDelDocumentoPagado.Trim()
                                    + "|" + "001"
                                    + "|" + "Tasa"
                                    + "|" + "0.040000"
                                    + "|" + totalisr
                                    //+ "|" + retencion
                                    + "|" + ipagado.Trim()
                                    + "| \r\n";
                                }

                                //if05 = "CPAG20DOCIMPRET"
                                //    + "|" + k1.Trim()
                                //    + "|" + k3.Trim()
                                //    + "|" + iva.Trim()
                                //    + "| \r\n";

                                //if06 = "CPAG20DOCIMPTRA"
                                //    + "|" + k1.Trim()
                                //    + "|" + k3.Trim()
                                //    + "|" + retencion
                                //    + "| \r\n";

                            }
                        }
                        f04 += "CPAG20DOC"
                             + "|" + identificaciondpago
                             + "|" + IdentificadorDelDocumentoPagado
                             + "|"
                             + "|"
                             + "|" + monedascpadgoc
                             + "|"
                             + "|" + nparcialidades
                             + "|" + interiorsaldoanterior
                             + "|" + ipagado
                             + "|" + isaldoinsoluto
                             + "|" + "02"
                             + "| \r\n"
                             + if05
                             + if06;
                        // Hasta aqui va en el ELSE

                        //foreach (DataRow rowIdentt in detalleIdentt.Rows)
                        //{
                        //    k1 = rowIdentt["K1"].ToString();
                        //    k3 = rowIdentt["K3"].ToString();
                        //    iva = rowIdentt["IVA"].ToString();
                        //    retencion = rowIdentt["RETENCION"].ToString();

                        //    if05 = "CPAG20DOCIMPRET"
                        //        + "|" + k1.Trim()
                        //        + "|" + k3.Trim()
                        //        + "|" + iva.Trim()
                        //        + "| \r\n";

                        //    if06 = "CPAG20DOCIMPTRA"
                        //        + "|" + k1.Trim()
                        //        + "|" + k3.Trim()
                        //        + "|" + retencion
                        //        + "| \r\n";

                        //}

                        //f04 += "CPAG20DOC"
                        //+ "|" + identificaciondpago
                        //+ "|" + IdentificadorDelDocumentoPagado
                        //+ "|"
                        //+ "|"
                        //+ "|" + monedascpadgoc
                        //+ "|"
                        //+ "|" + nparcialidades
                        //+ "|" + interiorsaldoanterior
                        //+ "|" + ipagado
                        //+ "|" + isaldoinsoluto
                        //+ "|" + "02"
                        //+ "| \r\n";






                        //"CPAGDOC"                                              //1-Tipo De Registro
                        //          + "|" + identpag                                       //2-IdentificadorDelPago
                        //                                                                 //+ "|" + rowIdent["IdentificadorDelDocumentoPagado"].ToString()                            //3-IdentificadorDelDocumentoPagado                                              
                        //          + "|" + uid                            //3-IdentificadorDelDocumentoPagado                                              
                        //          + "|" + serieinvoice                                      //4-Seriecpag
                        //          + "|" + foliocpag                                      //5-Foliocpag
                        //          + "|" + monedacpagdoc                                  //6-Monedacpag
                        //          + "|" + tipocambiocpag                                 //7-TipoCambiocpagdpc
                        //          + "|" + txtMetodoPago.Text                             //8-MetodoDePago
                        //          + "|" + numerodeparcialidad                            //9-NumeroDeParcialidad
                        //          + "|" + importeSaldoAnterior                           //10-ImporteSaldoAnterior
                        //          + "|" + importepago                                    //11-ImportePagado                                                  
                        //          + "|" + importesaldoinsoluto                           //12 ImporteSaldoInsoluto
                        //          + "| \r\n");
                    }
                }
                DataTable detalleIdent2 = facLabControler.detalleFacturas(folio);

                foreach (DataRow rowIdent2 in detalleIdent2.Rows)
                {
                    identificadorDelPago = rowIdent2["IdentificadorDelPago"].ToString();
                    DateTime dtdtt2 = DateTime.Parse(rowIdent2["Fechapago"].ToString());
                    fechapago = dtdtt2.ToString("yyyy'-'MM'-'dd'T'HH:mm:ss");
                    formadepagocpag = rowIdent2["Formadepagocpag"].ToString();
                    monedacpag = rowIdent2["Monedacpag"].ToString();
                    mmonto = rowIdent2["Monto"].ToString();

                    f03 += "CPAG20PAGO"
                        + "|" + identificadorDelPago
                        + "|" + fechapago
                        + "|" + formadepagocpag
                        + "|" + monedacpag
                        + "|" 
                        + "|" + mmonto
                        + "|"
                        + "|"
                        + "|"
                        + "|"
                        + "|"
                        + "|"
                        + "|"
                        + "|"
                        + "|"
                        + "|"
                        + "| \r\n";
                }

                //System.IO.File.WriteAllText(@"C:\Administración\Sistema complemento pago\TxtGenerados\" + datestring + "-Tralix2.txt", f03);
                string f01 = "01"                                                //1.-Tipo De Registro
                + "|" + idcomprobante                                      //2-ID Comprobante
                + "|" + seriee                                      //3-Serie
                + "|" + folioe                                      //4-Foliio 
                + "|" + fecha                 //5-Fecha y Hora De Emision
                + "|" + subt                                        //6-Subtotal
                + "|"                                         //7-Total Impuestos Trasladados
                + "|"                                         //8-Total Impuestos Retenidos
                + "|"                                               //9-Descuentos
                + "|" + total                                       //10-Total
                + "|"                        //11-Total Con Letra
                + "|" + formadepago                       //12-Forma De Pago
                + "|"                                         //13-Condiciones De Pago
                + "|" + metodopago33                                //14-Metodo de Pago
                + "|" + tmoneda                       //15-Moneda
                + "|"                                        //16-Tipo De Cambio
                + "|" + tipocomprobante                             //17-Tipo De Comprobante
                + "|" + lugarexpedicion                             //18-Lugar De Expedicion                                        
                + "|" + usocfdi                                     //19-Uso CFDI
                + "|"                               //20-Confirmacion
                + "|" + Tdoc                                     //21-Tipo documento
                + "|"                               //22-Exportacion
                + "|"                               //23-Aquiere
                + "|"
                + "| \r\n"
                //02-------------------------------------------------------------------------------------------------------------------------
                + "02"                                                   //1-Tipo De Registro
                   + "|" + IdCliente.Trim()                       //2-Id Receptor
                   + "|" + RFC.Trim()                                //3-RFC
                   + "|" + Cliente.Trim()                         //4-Nombre
                   + "|"                            //5-Pais
                   + "|"                             //6-Calle
                   + "|"                            //7-Numero Exterior
                   + "|"                             //8-Numero Interior
                   + "|"                          //9-Colonia
                   + "|"                         //10-Localidad
                   + "|"                        //11-Referencia
                   + "|"                         //12-Municio/Delegacion
                   + "|"                            //13-EStado
                   + "|" + CP.Trim()                              //14-Codigo Postal
                   + "|"                             // paisresidencia                                 //15-Pais de Residecia Fiscal Cuando La Empresa Sea Extrajera
                   + "|"                                   //16-Numero de Registro de ID Tributacion 
                   + "|"
                   + "|" + "601"    //17-Correo de envio                                                    
                   + "| \r\n"
                //04-------------------------------------------------------------------------------------------------------------------------
                + "04"                                                   //1-Tipo De Registro
                   + "|" + consecutivoconcepto.Trim()                       //2-Id Receptor
                   + "|" + claveproductoservicio.Trim()                                //3-RFC
                   + "|"                          //4-Nombre
                   + "|" + cantidad.Trim()                           //5-Pais
                   + "|" + claveunidad.Trim()                            //6-Calle
                   + "|"                             //7-Numero Exterior
                   + "|" + descripcion.Trim()                            //8-Numero Interior
                   + "|" + valorunitario.Trim()                         //9-Colonia
                   + "|" + importe.Trim()                        //10-Localidad
                   + "|"                        //11-Referencia
                   + "|"                         //12-Municio/Delegacion
                   + "|" + "02"                          //13-EStado
                   + "| \r\n"
                   //CPAG20-------------------------------------------------------------------------------------------------------------------------
                   + "CPAG20"
                   + "|" + "2.0"                                  //2-Identificador
                   + "| \r\n"
                   //CPAG20TOT-------------------------------------------------------------------------------------------------------------------------
                   + "CPAG20TOT"                         //1-Tipo De Registro
                   + "|"                               //2-TotalRetencionesIVA
                   + "|"                               //3-TotalRetencionesISR                                              
                   + "|"                               //4-TotalRetencionesIEPS
                   + "|"                               //5-TotalTrasladosBaseIVA16
                   + "|"                               //6-TotalTrasladosImpuestoIVA16
                   + "|"                               //7-TotalTrasladosBaseIVA8
                   + "|"                               //8-TotalTrasladosImpuestoIVA8
                   + "|"                               //9-TotalTrasladosBaseIVA0
                   + "|"                               //10-TotalTrasladosImpuestoIVA0
                   + "|"                               //11-TotalTrasladosBaseIVAExento
                   + "|" + Total                       //12-MontoTotalPagos
                   + "| \r\n"
                   + f03
                   + f04;

                //CPAG20DOC-------------------------------------------------------------------------------------------------------------------------






                System.IO.File.WriteAllText(@"C:\Administración\Sistema complemento pago\TxtGenerados\" + datestring + "-TralixTestPro.txt", f01);
                //Console.WriteLine(f01);
            }

            
        }
    }
}