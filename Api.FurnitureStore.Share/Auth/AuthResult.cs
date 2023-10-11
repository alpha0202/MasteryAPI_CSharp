using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.FurnitureStore.Share.Auth
{
    public class AuthResult
    {

        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }

    }
}
