using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Entidades
{
    /// <summary>
    ///  Clase Standard para ser utilizada para pasar el parametros a la base de datos.
    /// </summary>
    
    public class DBParametro
    {
        public DBParametro(string Nombre, DbType Tipo, object Valor)
        {
            this.Nombre = Nombre;
            this.Tipo = Tipo;
            this.Valor = Valor;
            
        }

        public DBParametro(string Nombre, DbType Tipo, object Valor,int scale)
        {
            this.Nombre = Nombre;
            this.Tipo = Tipo;
            this.Valor = Valor;
            this.Scale = scale;
        }

        private string nombre;
        private DbType tipo;
        private object valor;
        private int scale;
        
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Scale
        {
            get { return this.scale ; }
            set { this.scale = value; }
        }


        public DbType Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public object Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }
    }
}