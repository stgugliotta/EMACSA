using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Departamento 
    /// </summary>
  	public class DepartamentoAdmin
	{
		/// <summary>
        /// M?todo de lectura de objeto Departamento 
        /// </summary>
        /// <param name="id"></param>		
		/// <returns></returns>
		 public Departamento Load(int id)
			{
				Departamento oReturn = new Departamento();
				try
				{
					using (DALDepartamento dalDepartamento = new DALDepartamento())
                	{
						oReturn = dalDepartamento.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
		
		/// <summary>
        /// M?todo para eliminar un objeto Departamento
        /// </summary>
        /// <param name="oDepartamento"></param>
      	public void Delete(Departamento oDepartamento)
			{
				try
				{
					using (DALDepartamento dalDepartamento = new DALDepartamento())
					{
						dalDepartamento.Delete(oDepartamento);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}

        
		/// <summary>
        /// M?todo para Actualizar  un objeto Departamento 
		/// </summary>
        /// <param name="oDepartamento"></param>
     	public void Update(Departamento oDepartamento)
			{
				try
				{
					using (DALDepartamento dalDepartamento = new DALDepartamento())
					{
						dalDepartamento.Update(oDepartamento);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}
		
		/// <summary>
        /// M?todo para Inserta un Objeto Departamento 
		/// </summary>
        /// <param name="oDepartamento"></param>
     	public void Insert(Departamento oDepartamento)
		{
				try
				{
					using (DALDepartamento dalDepartamento = new DALDepartamento())
					{
						dalDepartamento.Insert(oDepartamento);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
			}


		/// <summary>
        /// M?todo de lectura de objeto Departamento 
		/// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>   
		/// <returns></returns>
		public Departamento GetDepartamento(int id)
			{
				Departamento oReturn = new Departamento();
				try
				{
					using (DALDepartamento dalDepartamento = new DALDepartamento())
                	{
						oReturn = dalDepartamento.Load( id);
					}
					
				}
				catch (Exception ex)
           		 {
                	throw ex;
				}
				return oReturn;
			}
			
		
		 /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Departamento
		/// de la tabla dbo.TBL_Departamento
        /// </summary>
        /// <returns></returns>
       	public List<Departamento> GetAllDepartamentos()
		{
			List<Departamento> lstDepartamento = new List<Departamento>();
            try
            {
                using (DALDepartamento dalDepartamento = new DALDepartamento())
                {
                    lstDepartamento = dalDepartamento.GetAllDepartamentos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDepartamento;
			
		}

        /// <summary>
        /// Metodo para traer una lista de la totalidad de los objetos Departamento por Provincia
        /// de la tabla dbo.TBL_Departamento
        /// </summary>
        /// <returns></returns>
        public List<Departamento> GetAllDepartamentosByProvincia(int idProvincia)
        {
            List<Departamento> lstDepartamento = new List<Departamento>();
            try
            {
                using (DALDepartamento dalDepartamento = new DALDepartamento())
                {
                    lstDepartamento = dalDepartamento.GetAllDepartamentosByProvincia(idProvincia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDepartamento;

        }
	}
}
