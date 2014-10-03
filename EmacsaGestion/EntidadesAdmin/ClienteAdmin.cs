using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;
using Interfaces;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Cliente 
    /// </summary>
    public class ClienteAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Cliente 
        /// </summary>
        /// <param name="idCliente"></param>		
        /// <returns></returns>
        public Cliente Load(decimal idCliente)
        {
            Cliente oReturn = new Cliente();
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    oReturn = dalCliente.Load(idCliente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Cliente
        /// </summary>
        /// <param name="oCliente"></param>
        public void Delete(Cliente oCliente)
        {
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    dalCliente.Delete(oCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Cliente 
        /// </summary>
        /// <param name="oCliente"></param>
        public void Update(Cliente oCliente)
        {
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    dalCliente.Update(oCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Cliente 
        /// </summary>
        /// <param name="oCliente"></param>
        public void Insert(Cliente oCliente)
        {
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    dalCliente.Insert(oCliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Cliente 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idCliente"></param>                  
        /// <returns></returns>
        public Cliente GetCliente(decimal idCliente)
        {
            Cliente oReturn = new Cliente();
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    oReturn = dalCliente.Load(idCliente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        public Cliente GetClienteByIdDeudor(decimal idDeudor)
        {
            Cliente oReturn = new Cliente();
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    oReturn = dalCliente.GetClienteByDeudor(idDeudor);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cliente
        /// de la tabla dbo.MTR_Cliente
        /// </summary>
        /// <returns></returns>
        public List<Cliente> GetAllClientes()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    lstCliente = dalCliente.GetAllClientes();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCliente;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cliente
        /// de la tabla dbo.MTR_Cliente
        /// </summary>
        /// <returns></returns>
        public List<Cliente> GetAllClientesByAnalista(string analista)
        {
            List<Cliente> lstCliente = new List<Cliente>();
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    lstCliente = dalCliente.GetAllClientesByAnalista(analista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCliente;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Cliente
        /// de la tabla dbo.MTR_Cliente
        /// </summary>
        /// <returns></returns>
        public List<Cliente> GetClientesInterfaces()
        {
            List<Cliente> lstCliente = null;
            List<Cliente> lstClienteInterfaz = new List<Cliente>();
            try
            {
                using (DALCliente dalCliente = new DALCliente())
                {
                    lstCliente = dalCliente.GetAllClientes();
                }

                foreach (Cliente cli in lstCliente) { 
                    Cliente cliDup = new Cliente();
                    cliDup.ACTIVO = cli.ACTIVO;
                    cliDup.ALTURA = cli.ALTURA;
                    cliDup.CALLE = cli.CALLE;
                    cliDup.CP = cli.CP;
                    cliDup.CUIT = cli.CUIT;
                    cliDup.DEPARTAMENTO = cli.DEPARTAMENTO;
                    cliDup.EMAIL = cli.EMAIL;
                    cliDup.FAX = cli.FAX;
                    cliDup.GruRec = cli.GruRec;
                    cliDup.IdCliente = cli.IdCliente * -1;
                    cliDup.LOCALIDAD = cli.LOCALIDAD;
                    cliDup.MonedaCredito = cli.MonedaCredito;
                    cliDup.NOMBRE = "** " + cli.NOMBRE ;
                    cliDup.NOMBRECORTO =  cli.NOMBRECORTO;
                    cliDup.OBSERVACIONES = cli.OBSERVACIONES;
                    cliDup.PROVINCIA = cli.PROVINCIA;
                    cliDup.SOLOGESTION = cli.SOLOGESTION;
                    cliDup.TELEFONOS = cli.TELEFONOS;
                    lstClienteInterfaz.Add(cli);
                    lstClienteInterfaz.Add(cliDup);  
                }

                /*ConfigurationInterfaz config = ConfigurationLoader.loadConfiguration();

                foreach (Cliente cli in lstCliente)
                {
                    if (searchClienteConfiguration(config, cli.IdCliente.ToString()) != null) {

                        lstClienteInterfaz.Add(cli);
                    }

                }*/

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return lstClienteInterfaz;
            return lstClienteInterfaz;

        }

        private static ClienteInterfaz searchClienteConfiguration(ConfigurationInterfaz config, String idCliente)
        {

            foreach (FacturaInterfaz fac in config.interfacesFactura)
            {

                foreach (ClienteInterfaz cli in fac.clientes)
                {
                    if (cli.id.ToString().Equals(idCliente))
                    {
                        return cli;
                    }
                }
            }

            return null;
        }

    }
}
