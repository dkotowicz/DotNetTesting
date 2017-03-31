using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ASP.ViewModels
{
    public class PersonAdres
    {
        public int personId { get; set; }

        [DisplayName("Imię")]
        [Required(ErrorMessage = "Podaj imię")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Podane imię jest za krótkie")]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$", ErrorMessage = "Podałeś złe imię")]
        public String imie { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Podaj nazwisko")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Podane nazwisko jest za krótkie")]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$", ErrorMessage = "Podałeś złe nazwisko")]
        public String nazwisko { get; set; }

        [DisplayName("Pesel")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Podałeś zły pesel")]
        [StringLength(11, ErrorMessage = "Pesel się składłada z 11 znaków")]
        public String pesel { get; set; }

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
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$", ErrorMessage = "Podałeś zły kod pocztowy")]
        public String kodPocztowy { get; set; }

        [DisplayName("Nr bloku")]
        [StringLength(5, ErrorMessage = "Podałeś zły nr bloku")]
        public String nrBloku { get; set; }

        [DisplayName("Nr mieszkania")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Podałeś zły nr mieszkania")]
        public string nrMieszkania { get; set; }
    }
}