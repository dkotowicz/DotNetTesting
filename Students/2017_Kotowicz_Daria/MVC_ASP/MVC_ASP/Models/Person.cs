using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ASP.Models
{
    public class Person
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
        public virtual Adres Adres { get; set; }
    }
}