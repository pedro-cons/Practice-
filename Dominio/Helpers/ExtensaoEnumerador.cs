using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace Dominio.Helpers
{
    public static class ExtensaoEnumerador
    {
        public static string GetDisplayName(this Enum item)
        {
            try
            {
                Type t = item.GetType();

                FieldInfo info = t.GetField(item.ToString("G"));

                var attr = info.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true).FirstOrDefault();
                if (attr != null)
                    return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attr).Name;

                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string GetDescription(this Enum item)
        {
            Type t = item.GetType();

            FieldInfo info = t.GetField(item.ToString("G"));

            var attr = info.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true).FirstOrDefault();
            if (attr != null)
                return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attr).Description;

            return string.Empty;
        }

        public static string GetShortName(this Enum item)
        {
            Type t = item.GetType();

            FieldInfo info = t.GetField(item.ToString("G"));

            var attr = info.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true).FirstOrDefault();
            if (attr != null)
                return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attr).ShortName;

            return string.Empty;
        }

        public static string GetGroupName(this Enum item)
        {
            Type t = item.GetType();

            FieldInfo info = t.GetField(item.ToString("G"));

            var attr = info.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true).FirstOrDefault();
            if (attr != null)
                return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attr).GroupName;

            return string.Empty;
        }

        public static int ToInt32(this Enum item)
        {
            return Convert.ToInt32(item);
        }

        public static List<KeyValuePair<string, int>> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");

            List<KeyValuePair<string, int>> enumValList = new List<KeyValuePair<string, int>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

                enumValList.Add(new KeyValuePair<string, int>((attributes.Length > 0) ? attributes[0].Name : e.ToString(), (int)e));
            }

            return enumValList;
        }

        public static SelectList EnumToSelectList<T>()
        {
            List<int> listaValor = new List<int>();
            Type type = typeof(T);
            if (type != null)
            {
                Array enumValues = Enum.GetValues(type);
                foreach (var value in enumValues)
                {
                    listaValor.Add(Convert.ToInt32(value));
                }
            }

            IList<string> listaNome = new List<string>();
            Type typeOf = typeof(T);
            if (typeOf != null)
            {
                Array enumValues = Enum.GetNames(typeOf);
                foreach (string value in enumValues)
                {
                    listaNome.Add(value);
                }
            }

            List<SelectListItem> listaSelect = new List<SelectListItem>();

            listaSelect.Add(new SelectListItem
            {
                Value = "",
                Text = "Selecione"
            });

            for (var i = 0; i < listaNome.Count; i++)
            {
                listaSelect.Add(new SelectListItem() { Text = listaNome[i], Value = listaValor[i].ToString(), Selected = true, Disabled = false });
            }

            return new SelectList(listaSelect, "Value", "Text");
        }

        public static SelectList EnumToSelectListOrderByText<T>()
        {
            List<int> listaValor = new List<int>();
            IList<string> listaNome = new List<string>();
            Type type = typeof(T);
            if (type != null)
            {
                Array enumValues = Enum.GetValues(type);
                foreach (var value in enumValues)
                {
                    listaValor.Add(Convert.ToInt32(value));
                    listaNome.Add(GetDisplayName((Enum)value));
                }
            }

            List<SelectListItem> listaSelect = new List<SelectListItem>();
            List<SelectListItem> listaSelect2 = new List<SelectListItem>();

            listaSelect.Add(new SelectListItem
            {
                Value = "",
                Text = "Selecione"
            });

            for (var i = 0; i < listaNome.Count; i++)
            {
                if (listaValor[i].ToString() == "0" || listaValor[i].ToString() == "")
                {
                    listaSelect.Add(new SelectListItem() { Text = listaNome[i], Value = listaValor[i].ToString(), Selected = true, Disabled = false });
                }
                else
                {
                    listaSelect2.Add(new SelectListItem() { Text = listaNome[i], Value = listaValor[i].ToString(), Selected = true, Disabled = false });
                }
            }

            listaSelect2 = listaSelect2.OrderBy(e => e.Text).ToList();
            listaSelect.AddRange(listaSelect2);

            return new SelectList(listaSelect, "Value", "Text");
        }
    }
}
