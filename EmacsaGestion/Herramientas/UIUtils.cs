using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
namespace Herramientas
{
    public class UIUtils
    {


        public static int GetPosCol(GridView gv, string headerName)
        {
            int position = -1;

            foreach (DataControlField item in gv.Columns)
            {
                position++;
                if (item.HeaderText.ToLower() == headerName.ToLower())
                {
                    return position;
                }
            }

            return -1;
        }

        public static void PaintSelectedRow(GridView gv, string keyField, string valueToSearch)
        {

            System.Drawing.Color col = System.Drawing.Color.Empty;

            foreach (GridViewRow item in gv.Rows)
            {

                item.BackColor = col;

            }

            foreach (GridViewRow item in gv.Rows)
            {

                if (item.Cells[UIUtils.GetPosCol(gv, keyField)].Text == valueToSearch)
                {

                    item.BackColor = System.Drawing.Color.Gold;

                }
            }

        }


        public static void PaintSelectedRow(GridView gv, string keyField, string valueToSearch, System.Drawing.Color color)
        {

            System.Drawing.Color col = System.Drawing.Color.Empty;

            foreach (GridViewRow item in gv.Rows)
            {

                item.BackColor = col;

            }

            foreach (GridViewRow item in gv.Rows)
            {

                if (item.Cells[UIUtils.GetPosCol(gv, keyField)].Text == valueToSearch)
                {

                    item.BackColor = color;

                }
            }

        }



        public static List<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("");

            Array enumValArray = Enum.GetValues(enumType);

            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        public static void MappingEntity(object source, object target)
        {

            if ((source == null) || (target == null))
            {
                return;
            }

            System.Collections.IEnumerator propiedades;

            propiedades = source.GetType().GetProperties().GetEnumerator();

            System.Reflection.PropertyInfo propiedad;

            object value;



            while (propiedades.MoveNext())
            {
                try
                {
                    propiedad = (System.Reflection.PropertyInfo)propiedades.Current;

                    value = propiedad.GetGetMethod().Invoke(source, null);

                    if (value != null)
                    {
                        object[] parameters = new object[1];

                        parameters[0] = value;
                        target.GetType().GetProperty(propiedad.Name).GetSetMethod().Invoke(target, parameters);
                    }
                }

                catch (Exception ex)
                {

                }
            }


        }


        /// <summary>
        /// Calcula el dígito verificador dado un CUIT completo o sin él.
        /// </summary>
        /// <param name="cuit">El CUIT como String sin guiones</param>
        /// <returns>El valor del dígito verificador calculado.</returns>
        public static int CalcularDigitoCuit(string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
       }

          /// <summary>
        /// Valida el CUIT ingresado.
        /// </summary>
        /// <param name="cuit" />Número de CUIT como string con o sin guiones
        /// <returns>True si el CUIT es válido y False si no.</returns>
        public static bool ValidaCuit(string cuit)
        {
            if (cuit == null)
            {
                return false;
            }
            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                return calculado == digito;
            }
        }
   }
}
