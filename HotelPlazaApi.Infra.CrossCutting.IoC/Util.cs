using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HotelPlazaApi.Infra.CrossCutting.IoC
{
    public static class Util
    {
        public static string StringValueOf(object valor)
        {
            try
            {
                FieldInfo fio = valor.GetType().GetField(valor.ToString());
                DescriptionAttribute[] descriptionAttribute = (DescriptionAttribute[])fio.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descriptionAttribute.Length > 0)
                    return descriptionAttribute[0].Description;
                else
                {
                    DisplayAttribute[] displayAttribute = (DisplayAttribute[])fio.GetCustomAttributes(typeof(DisplayAttribute), false);
                    if (displayAttribute.Length > 0)
                        return displayAttribute[0].Name;
                    else
                        return valor.ToString();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
