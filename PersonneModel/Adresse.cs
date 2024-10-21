using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Probleme
{
    public class Address
    {
        private string ville;
        private string code_postale;

        public Address(string ville, string code) {
            this.ville = ville;
            this.code_postale = code;
        }
        public string Ville { get { return ville; } }
        
         public override string ToString()
        {
            return "Ville : " + ville + " Code Postale : " + code_postale;
        }
    }
}