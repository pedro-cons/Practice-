using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Enumeradores
{
    /// <summary>
    /// UF´s
    /// </summary>
    public enum ETipoBotao
    {
        [Display(Name = "Menu")]
        Menu = 0,
        [Display(Name= "Link Externo")]
        LinkExterno = 1,
        [Display(Name= "Wi-Fi")]
        WiFi = 2,
        [Display(Name= "Whatsapp")]
        Whatsapp = 3,
    }
}
