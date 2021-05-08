using System;
using System.IO;
using System.Reflection;
using TiendaVirtual.Models;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TiendaVirtual.BusinessLogic.Utilities
{
    public class AuxiliarMethods
    {
        public static string GenerarURL(string categoria, string ImageName)
        {
            string url = Path.Combine(Constant.url_imagenes, categoria, ImageName);
            return url;
        }

        internal static FiltroProducto ValidarFiltros(FiltroProducto filtroProducto)
        {
            filtroProducto.STag = filtroProducto.STag.Trim().ToUpper();
            if (!((filtroProducto.IdCategoria.Trim()).Length > 0))
                filtroProducto.IdCategoria = "000";

            if (!((filtroProducto.IdMarca.Trim()).Length > 0))
                filtroProducto.IdMarca = "000";

            if (filtroProducto.Precio_Fin == 0)
                filtroProducto.Precio_Fin = 9999;

            return filtroProducto;
        }

        public static object ValidateParameters(object obj, Type model)
        {
            PropertyInfo[] properties = (model).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var Valor = property.GetValue(obj);
                if (Valor == null)
                {

                    var type = (property.Name).GetType().ToString();
                    switch (type)
                    {
                        case "System.int":

                            property.SetValue(obj, 0);
                            break;
                        case "System.String":
                            property.SetValue(obj, "");
                            break;
                    }
                }
            }
            return obj;
        }

        public static string ArmadoXML(object obj, Type model, string tipo)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(model);
            try
            {
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, obj);
                    xmlStream.Position = 0;
                    xmlDoc.Load(xmlStream);
                    string xml = CierreXML(xmlDoc.InnerXml, tipo);
                    return xml;
                }
            }
            catch (Exception) { }

            return "";
        }

        public static string CierreXML(string obj, string tipo)
        {
            string xml = "";
            string xlm_entrada = "<PAXLST_Message >";
            string xml_cierre = "</PAXLST_Message >";
            try
            {
                if (tipo == "Cliente")
                {
                    int tamaño = obj.Length - 136;
                    obj = obj.Substring(136, tamaño);
                    obj = obj.Replace("</ArrayOfCliente>", "");

                    xml = string.Concat(xlm_entrada, obj, xml_cierre);
                }
                if (tipo == "Pedido")
                {
                    int tamaño = obj.Length - 135;
                    obj = obj.Substring(136, tamaño);
                    obj = obj.Replace("</ArrayOfPedido>", "");

                    xml = string.Concat(xlm_entrada, obj, xml_cierre);
                }
            }
            catch (Exception) { }

            return xml;
        }
        public static string StandardXML(List<XMLStructure> lstXML)
        {
            string xml = "";
            string nodo = "";

            foreach (var item in lstXML)
            {
                string tablas = "";
                string datos = "";

                if (nodo != item.Entidad)
                {
                    tablas = "</" + nodo + "><" + item.Entidad + ">";
                }
                datos = "<" + item.Etiqueta + ">" + item.Valor + "</" + item.Etiqueta + ">";

                nodo = item.Entidad;

                xml += tablas + datos;
            }
            xml = xml[3..^0];
            //string version = @"<? xml version = ""2.0"" encoding = ""UTF-8"" ?>";
            // "" + version + 
            xml = "<PAXLST_Message >" + xml + "</" + nodo + "></PAXLST_Message >";

            return xml;
        }
    }
}
