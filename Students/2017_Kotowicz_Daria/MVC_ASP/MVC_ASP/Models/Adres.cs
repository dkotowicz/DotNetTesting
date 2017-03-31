using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ASP.Models
{
    public class Adres
    {
        public int adresId { get; set; }

        [DisplayName("Miasto")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Podana nazwa jest za krótka")]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$", ErrorMessage = "Podałeś złe miasto")]
        public String miasto { get; set; }

        [DisplayName("Ulica")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Podana nazwa jest za krótka")]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$", ErrorMessage = "Podałeś złą ulicę")]
        public String ulica { get; set; }

        [DisplayName("Kod pocztowy")]
        [StringLength(6, ErrorMessage = "Kod pocztowy składa się z 6 znaków")]
        [RegularExpression(@"^[0-9][0-9]-[0-9][0-9][0-9]$", ErrorMessage = "Podałeś zły kod pocztowy")]
        public String kodPocztowy { get; set; }

        [DisplayName("Nr bloku")]
        [StringLength(5, ErrorMessage = "Podałeś zły nr bloku")]
        public String nrBloku { get; set; }

        [DisplayName("Nr mieszkania")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Podałeś zły nr mieszkania")]
        public string nrMieszkania { get; set; }
    }
}