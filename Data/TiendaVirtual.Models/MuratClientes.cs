using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Models
{
    public class MuratClientes
    {
        public int IdCliente { get; set; }
        public string SCorreo { get; set; }
        public string SNombre { get; set; }
        public string SApellido { get; set; }
        public string SNombre_Largo { get; set; }
        public string SNro_Telefono { get; set; }
        public string Contrasena { get; set; }
	}
	public class Cliente
	{
		public int Cod_Documento { get; set; }
		public string SNro_Documento { get; set; }
		public string SCliente { get; set; }
		public int Cod_Rubro { get; set; }
		public int IdPais { get; set; }
		public int IdDepartamento { get; set; }
		public int IdProvincia { get; set; }
		public int IdDistrito { get; set; }
		public string SDireccion { get; set; }
		public string SReferencia { get; set; }
		public string SContacto { get; set; }
		public string SCorreo1 { get; set; }
		public string SCorreo2 { get; set; }
		public string NTelefono1 { get; set; }
		public string NTelefono2 { get; set; }
		public string NTelefono3 { get; set; }
		public string SPaginaWeb { get; set; }
		public int Cod_RedesSocial1 { get; set; }
		public string SRedesSocial1 { get; set; }
		public int Cod_RedesSocial2 { get; set; }
		public string SRedesSocial2 { get; set; }
		public string SComentario { get; set; }
		public int Cod_Categoria { get; set; }
		public int Cod_Origen { get; set; }
	}
	public class ClienteRequest
    {
		public string SCliente { get; set; }
		public string SRuc { get; set; }
		public int Categoria { get; set; }
		public int IdUsuario { get; set; }
	}
	
	public class ClienteResponse
	{
		public string SNRO_DOCUMENTO { get; set; }
		public string SCLIENTE { get; set; }
		public string RUBRO { get; set; }
		public string SCONTACTO { get; set; }
		public string TELEFONO { get; set; }
		public string CATEGORIA { get; set; }
		public int IDCLIENTE { get; set; }
		public int IDUSUARIO { get; set; }
	}
}
